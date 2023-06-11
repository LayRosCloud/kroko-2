using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject [] _blocks;
    
    [SerializeField] private float _spawnCooldownBlocks;
    [SerializeField] private float _spawnFirstBlock;

    [SerializeField] private GameObject[] _spawnPoints;

    private int lastIndex;
    private bool _isStarted;
    private Coroutine _spawnBlockCoroutine;
    public bool IsStartGame { get; set; } = false;

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

        int indexSpawnedObject = Random.Range(0, _blocks.Length);
        GameObject spawnedObject = _blocks[indexSpawnedObject];

        GameObject spawned = Instantiate(spawnedObject);
        spawned.transform.position = _spawnPoints[index].transform.position;
    }
}
