using System;
using System.Collections;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [SerializeField] private float _timeChange = 0.1f;
    [SerializeField] private PlayerJump _player;
    [SerializeField] private float _limitSpeed = 2f;
    private Spawner _spawner;
    private Coroutine _addCooldownCoroutine;
    private float gravity = -9.81f;
    public int Difficulty { get; private set; } = 1;
    
    public float CurrentSpeed { get; private set; } = 1f;

    private int _counter = 1;
    
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
         if (_counter++ % 100 == 0 && Difficulty < 3)
         {
             Difficulty++;
         }
         
         if (CurrentSpeed < (_limitSpeed * Difficulty))
         {
              CurrentSpeed += 0.02f;
         }
         
         if ((-22 * Difficulty) < gravity)
         {
              gravity -= 0.25f;
              Physics.gravity = new Vector3(0, gravity);
              _player.JumpForce += 0.1f;
         }
          
         _spawner.SetSpawnCooldownBlocks(_spawner.SpawnCooldownBlocks - 1f / 120f);
          
         _addCooldownCoroutine = null;
    }
}
