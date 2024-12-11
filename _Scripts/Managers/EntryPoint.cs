using UnityEngine;
using System.Collections;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private BookManager _bookManager;
    [SerializeField] private DataView _dataView;

    private IEnumerator Start()
    {
        _bookManager.enabled = true;

        yield return new WaitForSeconds(5f);

           
    }
}
