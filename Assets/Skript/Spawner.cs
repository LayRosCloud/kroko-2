using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] BlockVar;
    private float timeBtsSopawn;
    public float startTimeBtsSpawn;
    public bool Raz = false;


    private void Update()
    {
        if (Raz)
        {
            if (timeBtsSopawn <= 0)
            {
                int rand = Random.Range(0, BlockVar.Length);
                Instantiate(BlockVar[rand], transform.position, Quaternion.identity);
                timeBtsSopawn = startTimeBtsSpawn;
            }
            else
            {
                timeBtsSopawn -= Time.deltaTime;
            }
        }
    }
}
