using UnityEngine;

public static class AudioParser
{
    public static AudioClip[] GetAudioClips(string folderName)
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>($"Sounds/FairyTalesAudio/{folderName}");
        Resources.UnloadUnusedAssets();
        return audioClips;
    }
}