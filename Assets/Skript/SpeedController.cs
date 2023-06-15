using System;
using System.Collections;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float CurrentSpeed { get; private set; } = 1f;
    [SerializeField] private float _timeChange = 0.1f;
    [SerializeField] private Player _player;
    [SerializeField] private float _limitSpeed = 2f;
    private Spawner _spawner;
    private Coroutine _addCooldownCoroutine;
    private float gravity = -9.81f;
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
         counter++;
         
          if (CurrentSpeed < _limitSpeed)
          {
              CurrentSpeed += 0.02f;
          }
         
          if (-22 < gravity)
          {
              gravity -= 0.25f;
              Physics.gravity = new Vector3(0, gravity);
              _player.JumpForce += 0.1f;
          }

          if (counter == 90)
          {
              Physics.gravity = new Vector3(0, -30);
          }
          _spawner.SetSpawnCooldownBlocks(_spawner.SpawnCooldownBlocks - 1f / 120f);
          //Debug.Log($"{counter}. CurrentSpeed = {CurrentSpeed}; gravity={gravity}; spawnerCooldown = {_spawner.SpawnCooldownBlocks}; jump force = {_player.JumpForce}");
          
         _addCooldownCoroutine = null;
    }
}
