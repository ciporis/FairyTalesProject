using UnityEngine;

public class MusicButtonHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private ScriptableObject _mainMenuSettings;

    private bool _musicState;

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
        
    }

    private void TurnOffMusic()
    {
        _music.Stop();
        
    }

}
