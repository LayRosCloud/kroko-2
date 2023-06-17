
using System;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _stepAudio;

    private void OnEnable()
    {
        PlayerEvents.Instance.RightMoveEvent += PlayStep;
        PlayerEvents.Instance.LeftMoveEvent += PlayStep;
        PlayerEvents.Instance.DeathEvent += PlayDeathSound;
        PlayerEvents.Instance.JumpEvent += PlayJumpSound;
    }

    private void PlayJumpSound()
    {
        _jumpSound.Play();
    }
    
    private void PlayDeathSound()
    {
        _deathSound.Play();
    }

    private void PlayStep()
    {
        _stepAudio.Play();
    }
}
