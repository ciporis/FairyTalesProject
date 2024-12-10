using UnityEngine;

public class BookView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _fairyTaleSceneNumber;
    [SerializeField] private BookOpener _bookOpener;

    [SerializeField] private BoxCollider _bookOpenerCollider;

    private bool _isReadyToOpen;
    private string _openTrigger = "Open";

    private void Update()
    {
        if(transform.position.x == Mathf.Clamp(transform.position.x, -5f, 3.55f))
            _isReadyToOpen = true;
    }

    private void OnMouseUpAsButton()
    {
        if(_isReadyToOpen)
        {
            _animator.SetTrigger(_openTrigger);
            _isReadyToOpen = false;
        }
    }
}
