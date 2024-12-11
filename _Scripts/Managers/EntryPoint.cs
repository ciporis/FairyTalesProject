using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private BookManager _bookManager;
    [SerializeField] private DataView _dataView;

    private void Start()
    {
        _bookManager.enabled = true;
        _dataView.enabled = true;
        
    }
}
