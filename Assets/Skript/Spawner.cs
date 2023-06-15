using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpeedController))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject [] _blocks;
    
    [SerializeField] private float _spawnCooldownBlocks;
    [SerializeField] private float _spawnFirstBlock;

    [SerializeField] private float _spawnCooldownLimit;
    
    [SerializeField] private GameObject[] _spawnPoints;
    private SpeedController _speedController;
    private int lastIndex;
    private bool _isStarted;
    private Coroutine _spawnBlockCoroutine;
    private Coroutine _changeSpeed;

    public float SpawnCooldownLimit => _spawnCooldownLimit;

    public float SpawnCooldownBlocks => _spawnCooldownBlocks;
    public bool IsStartGame { get; set; } = false;

    private void Awake()
    {
        _speedController = GetComponent<SpeedController>();
    }

    public void SetSpawnCooldownBlocks(float value)
    {
        if (value < _spawnCooldownLimit)
        {
            value = _spawnCooldownLimit;
        }
        
        _spawnCooldownBlocks = value;
    }
    private void Update()
    {
        if (IsStartGame == false)
        {
            return;
        }
        
        if (_spawnBlockCoroutine == null)
        {
            _spawnBlockCoroutine = StartCoroutine(SpawnWithCooldown());
        }
    }
    

    private IEnumerator SpawnWithCooldown()
    {
        if (_isStarted == false)
        {
            _isStarted = true;
            yield return new WaitForSeconds(_spawnFirstBlock);
        }
        else
        {
            yield return new WaitForSeconds(_spawnCooldownBlocks);
        }
        
        _speedController.AddValue();
        
        Spawn(RandomPointSpawn(), GenerateSpawnedBlockIndex());
        _spawnBlockCoroutine = null;
    }

   private int RandomPointSpawn()
    {
        int index = Random.Range(0, _spawnPoints.Length);
        
        while (lastIndex == index)
        {
            index = Random.Range(0, _spawnPoints.Length);
        }

        lastIndex = index;

        return index;
    }

   private int GenerateSpawnedBlockIndex()
   {
       int range = Random.Range(0, 100);
        
       int spawnedObject;
       
       if (range < 10)
       {
           spawnedObject = 1;
       }
       else if (range < 30)
       {
           spawnedObject = 2;
       }
       else
       {
           spawnedObject = 0;
       }

       return spawnedObject;
   }
   
   public void Spawn(int pointSpawn, int blockIndex)
   {
       GameObject spawned = Instantiate(_blocks[blockIndex]);
       spawned.transform.position = _spawnPoints[pointSpawn].transform.position;
   }
}
