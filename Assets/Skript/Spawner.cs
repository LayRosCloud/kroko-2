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

    public float SpawnCooldownBlocks => _spawnCooldownBlocks;
    public bool IsStartGame { get; set; } = false;

    private void Awake()
    {
        _speedController = GetComponent<SpeedController>();
    }

    public void SetSpawnCooldownBlocks(float value)
    {
        if (_spawnCooldownBlocks + value < _spawnCooldownLimit)
        {
            _spawnCooldownBlocks = _spawnCooldownLimit;
            throw new ArgumentException("Достигнут лимит");
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
        
        Spawn();
        _spawnBlockCoroutine = null;
    }

   private void Spawn()
    {
        int index = Random.Range(0, _spawnPoints.Length);
        
        while (lastIndex == index)
        {
            index = Random.Range(0, _spawnPoints.Length);
        }

        lastIndex = index;

        int indexSpawnedObject = Random.Range(0, 100);
        GameObject spawnedObject = null;
        if (indexSpawnedObject < 10)
        {
            spawnedObject = _blocks[1];
        }
        else if (indexSpawnedObject < 30)
        {
             spawnedObject = _blocks[2];
        }
        else
        {
            spawnedObject = _blocks[0];
        }
        
        //GameObject spawnedObject = _blocks[indexSpawnedObject];

        GameObject spawned = Instantiate(spawnedObject);
        spawned.transform.position = _spawnPoints[index].transform.position;
    }
}
