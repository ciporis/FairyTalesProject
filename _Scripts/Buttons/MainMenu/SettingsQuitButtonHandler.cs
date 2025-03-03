using UnityEngine;
using UnityEngine.UI;

public class SettingsQuitButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _settingsMenu;

    [SerializeField] private GameObject[] _systemsForEnabling;
    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        for (int i = 0; i < _systemsForEnabling.Length; i++)
        {
            _systemsForEnabling[i].SetActive(true);
        }
        _settingsMenu.SetActive(false);   
    }
}
