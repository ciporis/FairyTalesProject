using System;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private BookView _bookView;
    [SerializeField] private string _fairyTaleName;


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
        BookData.FairyTaleName = _fairyTaleName;
    }
}