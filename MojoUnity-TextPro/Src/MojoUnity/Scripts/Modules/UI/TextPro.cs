/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-TextPro
 *
 * Since  : 2021-1-11
 * Update : 2021-6-3
 * Author : scott.cgi
 */

using System; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MojoUnity
{
    /// <summary>
    /// Text can add images or control each chars.
    /// 
    /// The material must not be 0 (<quad material!=0/>),
    /// so that the <quad/> vertex data will at end of VertexHelper when OnPopulateMesh.
    ///
    /// [UGUI Text Bug]:
    /// 
    /// 1. If Text VerticalWrapMode is Truncate and the text is truncated,
    ///    then the <quad/> will not display right and the toFill vertexes are disordered.
    ///
    /// 2. If <quad/> size is lager than 500,
    ///    then the <quad/> height and position will calculate error
    ///    by [cachedTextGeneratorForLayout.GetPreferredHeight]. 
    /// </summary>
    public class TextPro : Text
    {
        public struct SpriteInfo
        {
            public Sprite  sprite;
            public Vector2 size;
            public bool    isCenter;
            public Action  OnClick;
        }


        /// <summary>
        /// The current click Image.
        /// </summary>
        public Image CurrentClickImage { get; private set; }


        /// Sprites display at tag <quad/> position
        private readonly List<SpriteInfo> spriteInfoList    = new List<SpriteInfo>();
        /// Sprite scale when isCenter is true  
        private const    float            SpriteCenterScale = 1.35f;


        protected override void Start()
        {
            base.Start();

            if (this.horizontalOverflow != HorizontalWrapMode.Wrap)
            {
                this.horizontalOverflow = HorizontalWrapMode.Wrap;
                Debug.LogWarning("TextPro needs set [horizontalOverflow] to [Wrap].");
            }


            if (this.verticalOverflow != VerticalWrapMode.Overflow)
            {
                this.verticalOverflow = VerticalWrapMode.Overflow;
                Debug.LogWarning
                (
                    "TextPro needs set [verticalOverflow] to [Overflow]." +
                    "This can block <quad/> height caculation error in some cases. "
                );
            }
        }


        /// <summary>
        /// Add Image to <quad/> pos in text.
        /// </summary>
        public void AddImage(SpriteInfo spriteInfo)
        {
            this.spriteInfoList.Add(spriteInfo);

            var   spriteCount = this.spriteInfoList.Count;
            Image image;

            if (spriteCount <= this.transform.childCount)
            {
                var go       = this.transform.GetChild(spriteCount - 1).gameObject;
                go.SetActive(true);

                image        = go.GetComponent<Image>();
                image.sprite = null;
            }
            else
            {
                image        = this.gameObject.AddChild<Image>();
            }

            image.name                    = "Image-" + spriteInfo.sprite.name;
            image.sprite                  = spriteInfo.sprite;
            image.rectTransform.sizeDelta = spriteInfo.size;
            image.rectTransform.SetScaleXY(1.0f);

            if (spriteInfo.OnClick != null)
            {
                var btn = image.gameObject.GetComponent<Button>();

                if (btn == null)
                {
                    btn = image.gameObject.AddComponent<Button>();
                    btn.onClick.AddListener
                    (
                        () =>
                        {
                            this.CurrentClickImage = image;
                            spriteInfo.OnClick();
                            this.CurrentClickImage = null;
                        }
                    );
                }
            }
            else
            {
                Destroy(image.gameObject.GetComponent<Button>());
            }
        }


        /// <summary>
        /// Add Images to each <quad/> pos in text. 
        /// </summary>
        public void AddImages(IEnumerable<SpriteInfo> SpriteInfos)
        {
            var enumerator = SpriteInfos.GetEnumerator();

            while (enumerator.MoveNext())
            {
                this.AddImage(enumerator.Current);
            }

            enumerator.Dispose();
        }


        /// <summary>
        /// Clear all Images and SpriteInfos.
        /// </summary>
        public void ClearImages()
        {
            this.spriteInfoList.Clear();

            var childCount = this.transform.childCount;

            for (var i = 0; i < childCount; ++i)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }


        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            base.OnPopulateMesh(toFill);

            var count = this.spriteInfoList.Count;

            // display sprites at <quad/> postion 
            if (count > 0)
            {
                var vertexLastIndex = toFill.currentVertCount - 1;
                var spriteLastIndex = count                   - 1;
                var leftBottom      = new UIVertex();

                // if <quad material!=0/> then the <quad/> data at the end of toFill
                for (var i = spriteLastIndex; i > -1; --i)
                {
                    // remove <quad/> display from last
                    var index = vertexLastIndex - (spriteLastIndex - i) * 4;

                    toFill.PopulateUIVertex(ref leftBottom, index);     // LB
                    toFill.SetUIVertex     (    leftBottom, index - 1); // RB
                    toFill.SetUIVertex     (    leftBottom, index - 2); // RT
                    toFill.SetUIVertex     (    leftBottom, index - 3); // LT

                    // get image from last
                    var imageRT = this.transform.GetChild(i).GetComponent<Image>().rectTransform;
                    var pos     = (Vector2) leftBottom.position + imageRT.sizeDelta / 2;

                    if (this.spriteInfoList[i].isCenter)
                    {
                        pos.x += (this.rectTransform.rect.width - imageRT.rect.width) / 2;
                        imageRT.SetScaleXY(SpriteCenterScale);
                    }

                    // set sprite pos by <quad/> vertex pos
                    imageRT.SetLocalPositionXY(pos);
                }                  
            }
        }
    }
}