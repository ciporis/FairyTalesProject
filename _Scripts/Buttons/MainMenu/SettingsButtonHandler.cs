using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private Button _button;

    [SerializeField] private GameObject[] _systemsForDisabling;

    private void Awake()
    {
        _button.onClick.AddListener(ChangeSettingsMenuState);
        _button.onClick.AddListener(ChangeOtherSystemsState);
    }

    private void ChangeSettingsMenuState()
    {
        _settingsMenu.SetActive(true);
    }

    private void ChangeOtherSystemsState()
    {
        for (int i = 0; i < _systemsForDisabling.Length; i++)
        {
            _systemsForDisabling[i].SetActive(false);
        }
    }
}
