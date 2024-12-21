using UnityEngine;

public static class ImagesParser
{
    public static Sprite[] GetSlides(string folderName)
    {
        Sprite[] slides = Resources.LoadAll<Sprite>($"FairyTalesSlides/{folderName}");
        Resources.UnloadUnusedAssets();
        return slides;
    }
}
