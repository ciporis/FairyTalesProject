using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _fairyTaleSceneNumber;

    private bool _isReadyToOpen;
    private string _openTrigger = "Open";

    private void Update()
    {
        if(transform.position.x == Mathf.Clamp(transform.position.x, -4.01f, 4.03f))
            _isReadyToOpen = true;
    }

    private void OnMouseUpAsButton()
    {
        StartCoroutine(OpenBook());
    }

    private IEnumerator OpenBook()
    {
        if (_isReadyToOpen)
        {
            _animator.SetTrigger(_openTrigger);
            //float animationLength = _animator.GetCurrentAnimatorClipInfo(0).Length;
            yield return new WaitForSeconds(2.35f);
            SceneManager.LoadScene(_fairyTaleSceneNumber);
            _isReadyToOpen = false;
        }
    }
}