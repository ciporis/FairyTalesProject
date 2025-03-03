using UnityEngine;
using UnityEngine.UI;

public class OtherSystemsChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _systemsForDisabling;
    [SerializeField] private GameObject[] _systemsForEnabling;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(EnableSystems);
        _button.onClick.AddListener(DisableSystems);
    }

    private void EnableSystems()
    {
        for (int i = 0; i < _systemsForEnabling.Length; i++)
        {
            _systemsForEnabling[i].SetActive(true);
        }
    }

    private void DisableSystems()
    {
        for (int i = 0; i < _systemsForDisabling.Length; i++)
        {
            _systemsForDisabling[i].SetActive(false);
        }
    }
}
