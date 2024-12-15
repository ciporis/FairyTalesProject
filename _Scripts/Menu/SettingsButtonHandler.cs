using UnityEngine;

public class SettingsButtonHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _clickTrigger = "Click";

    public void HandleClick()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger(_clickTrigger);
    }
}
