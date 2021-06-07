/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-TextPro
 *
 * Since  : 2021-5-27
 * Update : 2021-5-27
 * Author : scott.cgi
 */

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using static MojoUnity.TextPro;

namespace MojoUnity
{
    /// <summary>
    /// The tag [spriteName, clickName] will add Image with Sprite by [spriteName] and Button with onClick by [clickName].
    /// </summary>
    [RequireComponent(typeof(TextPro))]
    public class TextProQuad : MonoBehaviour, ISerializationCallbackReceiver
    {
        public  char                                   tagStartChar   = '[';
        public  char                                   tagEndChar     = ']';
        public  char                                   tagSplitChar   = ',';
        [Tooltip("Sprite scale by fontSze / baseFontSize.")]
        public  int                                    baseFontSize   = 60;

        [Space(10)]
        public  SerializationSpriteDict                spriteDict;
        public  SerializationEventDict                 eventDict;

        /// <summary>
        /// Set by TextProQuad.
        /// </summary>
        public  TextPro                                TextPro      { get; private set; }

        /// <summary>
        /// The original text in TextPro.
        /// </summary>
        public  string                                 OriginalText { get; private set; }

        private RectTransform                          textProRT;
        private readonly StringBuilder                 sb             = new StringBuilder();
        private readonly List<SpriteInfo>              spriteInfoList = new List<SpriteInfo>();


        private void Start()
        {
            this.TextPro   = this.GetComponent<TextPro>();
            this.textProRT = this.transform as RectTransform;
            this.SetTextProText(this.TextPro.text);
        }


        /// <summary>
        /// Replace tags in text and set new text to TextPro.
        /// </summary>
        public void SetTextProText(string text)
        {
            var len  = text.Length;
            var pos  = -1;
            var last = -1;

            for (var i = 0; i < len; ++i)
            {
                var c = text[i];

                if (c == tagStartChar)
                {
                    pos = i;
                }
                else if (c == tagEndChar)
                {
                    var values = text.Substring(pos + 1, i - pos - 1).Split(this.tagSplitChar);
                    var vLen   = values.Length;

                    // handle Sprite
                    if (this.spriteDict.TryGetValue(values[0].Trim(), out Sprite sprite))
                    {
                        var size = sprite.GetRatioSizeByMax
                                   (
                                      this.textProRT.rect.width,
                                      // if <quad/> size is lager than 500,
                                      // then the height and position will calculate error
                                      // by [cachedTextGeneratorForLayout.GetPreferredHeight]
                                      500.0f,
                                      this.TextPro.fontSize / (float) this.baseFontSize
                                   );

                        this.sb.Append(text.Substring(last + 1, pos - last - 1))
                               .Append($"<quad material=1 size={size.y:0000} width={size.x / size.y:0.000} />");

                        var spriteInfo = new SpriteInfo
                        {
                            sprite = sprite,
                            size   = size,
                        };

                        // record the end pos of last tag 
                        last = i;

                        if (vLen > 1)
                        {
                            // handle event
                            if (this.eventDict.TryGetValue(values[1].Trim(), out UnityEvent unityEvent))
                            {
                                spriteInfo.OnClick = () => unityEvent.Invoke();
                            }
                            else
                            {
                                Debug.LogError
                                (
                                    $"TextProQuad({this.name}) cannot found the Sprite({values[0]}) event = {values[1]}."
                                );
                            }
                        }

                        this.spriteInfoList.Add(spriteInfo);
                    }
                }
            }

            // clear pre images
            this.TextPro.ClearImages();
            this.OriginalText = text;

            // text has tags
            if (this.sb.Length > 0)
            {
                this.sb.Append(text.Substring(last + 1, len - 1 - last));
                text = this.sb.ToString();
                this.sb.Clear();

                this.TextPro.AddImages(this.spriteInfoList);
                this.spriteInfoList.Clear();
            }

            this.TextPro.text = text;
        }


        public void OnBeforeSerialize()
        {
            this.spriteDict.SetSerializationKeys((sprite) => sprite ? sprite.name : null);
            this.eventDict.SyncSerializationKeysAndValues();
        }


        public void OnAfterDeserialize()
        {
            this.spriteDict.Deserialize();
            this.eventDict.Deserialize();
        }
    }
}

