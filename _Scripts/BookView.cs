using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _fairyTaleSceneNumber;
    [SerializeField] private Collider _openZone;
    [SerializeField] private Transform _openZoneCords;
    [SerializeField] private PageSwiper _pageSwiper;

    private bool _isReadyToOpen = false;
    private string _openTrigger = "Open";

    private float _distanceToBound;
    private float _rightBoundX;
    private float _leftBoundX;

    private void Start()
    {
        _distanceToBound = _openZone.bounds.size.x / 2;
        _rightBoundX = _openZoneCords.position.x + _distanceToBound;
        _leftBoundX = _openZoneCords.position.x - _distanceToBound;
    }

    private void Update()
    {
        if (transform.position.x >= _leftBoundX && transform.position.x <= _rightBoundX)
        {
            _isReadyToOpen = true;
        }        
        else
            _isReadyToOpen = false;
    }

    private void OnMouseUpAsButton()
    {
        if (_isReadyToOpen)
        {
            _pageSwiper.enabled = false;
            StartCoroutine(OpenBook());
        }      
    }

    private IEnumerator OpenBook()
    {
        _animator.SetTrigger(_openTrigger);
        //float animationLength = _animator.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(2.35f);
        SceneManager.LoadScene(_fairyTaleSceneNumber);
        _isReadyToOpen = false;
    }
}