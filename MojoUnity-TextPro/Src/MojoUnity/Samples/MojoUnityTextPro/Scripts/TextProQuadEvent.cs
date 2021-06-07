/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-TextPro
 *
 * Since  : 2021-6-1
 * Update : 2021-6-1
 * Author : scott.cgi
 */

using MojoUnity;
using UnityEngine;
using UnityEngine.UI;

public class TextProQuadEvent : MonoBehaviour
{
    private string oldText;


    public void Emoji0(Text text)
    {
        text.CrossFadeColor(Color.red, 0.3f, false, true);
    }


    public void Emoji1(Text text)
    {
        text.CrossFadeColor(Color.black, 0.3f, false, true);
    }


    public void Emoji2(Text text)
    {
        text.CrossFadeColor(Color.white, 0.3f, false, true);
    }


    public void Emoji3(TextProQuad textProQuad)
    {
        this.oldText = textProQuad.OriginalText;
        textProQuad.SetTextProText("[Emoji_4, Emoji4]");
    }


    public void Emoji4(TextProQuad textProQuad)
    {
        if (this.oldText != null)
        {
            textProQuad.SetTextProText(this.oldText);
        }
    }


    public void Emoji5(TextProQuad textProQuad)
    {
        var names = new string[] { "Emoji_0", "Emoji_1", "Emoji_2", "Emoji_3", "Emoji_4", "Emoji_5" };
        var name  = names[UnityEngine.Random.Range(0, names.Length)];
        textProQuad.TextPro.CurrentClickImage.sprite = textProQuad.spriteDict[name];
    }
}
