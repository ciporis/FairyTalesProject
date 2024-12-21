using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private BookOpener _bookView;

    public string PrefabFairyTaleName;

    private void OnEnable()
    {
        _bookView.BookOpened += SetFairyTaleName;
    }

    private void OnDisable()
    {
        _bookView.BookOpened -= SetFairyTaleName;
    }

    private void SetFairyTaleName()
    {
        BookData.FairyTaleName = PrefabFairyTaleName;
    }
}