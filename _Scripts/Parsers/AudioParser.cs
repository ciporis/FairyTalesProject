using UnityEngine;

public static class AudioParser
{
    public static AudioClip[] GetAudioClips(string folderName, string language)
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>($"Content/{language}/Sounds/FairyTalesAudio/{folderName}");
        Resources.UnloadUnusedAssets();
        return audioClips;
    }
}