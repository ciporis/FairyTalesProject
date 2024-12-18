using Unity.VisualScripting;
using UnityEngine;

public class MusicButtonHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private bool _musicState;

    private void Awake()
    {
        _musicState = MainMenu_Settings.MusicState;
    }

    public void HandleClick()
    {
        if (_musicState)
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
        _musicState = true;
    }

    private void TurnOffMusic()
    {
        _music.Stop();
        _musicState = false;
    }

}
