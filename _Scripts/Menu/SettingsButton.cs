using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _clickTrigger = "Click";

    public void PlayAnimation()
    {
        _animator.SetTrigger(_clickTrigger);
    }
}
