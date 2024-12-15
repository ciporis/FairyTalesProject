using UnityEngine;

public static class ImagesParser
{
    public static Sprite[] GetSlides(string fileName)
    {
        Sprite[] slides = Resources.LoadAll<Sprite>($"FairyTalesSlides/{fileName}");
        return slides;
    }
}
