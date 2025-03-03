using System;
using UnityEngine;

public static class ImagesParser
{
    public static Sprite[] GetSlides(string directory)
    {
        Sprite[] resources = Resources.LoadAll<Sprite>($"Content/FairyTalesSlides/{directory}");

        Sprite[] slides = new Sprite[resources.Length];

        for (int i = 0; i < resources.Length; i++)
            slides[Convert.ToInt32(resources[i].name) - 1] = resources[i];

        Resources.UnloadUnusedAssets(); 

        return slides;
    }
}
