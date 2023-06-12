using System;
using System.Collections;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float CurrentSpeed { get; private set; } = 1f;
    [SerializeField] private float _timeChange = 0.1f;
    [SerializeField] private Player _player;
    [SerializeField] private float _limitSpeed = 8f;
    private Spawner _spawner;
    private Coroutine _addCooldownCoroutine;
    private int counter = 0;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    public void AddValue()
    {
        if (_addCooldownCoroutine == null)
        {
            _addCooldownCoroutine = StartCoroutine(CooldownAdded());
        }
    }

    private IEnumerator CooldownAdded()
    {
         yield return new WaitForSeconds(_timeChange);
         if (CurrentSpeed < _limitSpeed)
         {
             CurrentSpeed += _limitSpeed / 400f;
         }
         _player.Rigidbody.mass += 150f;
         _spawner.SetSpawnCooldownBlocks(_spawner.SpawnCooldownBlocks - 1f / 100f);
         Debug.Log(counter++);
         _addCooldownCoroutine = null;
    }
}
