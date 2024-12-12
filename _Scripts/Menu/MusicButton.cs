using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    public void HandleClick()
    {
        if (Settings.MusicCondition == true)
        {
            TurnOffMusic();
        }
        else
        {
            TurnOnMusic();
        }
    }

    private void TurnOnMusic()
    {
        _music.Play();
        Settings.MusicCondition = true;
    }

    private void TurnOffMusic()
    {
        _music.Stop();
        Settings.MusicCondition = false;
    }

}
