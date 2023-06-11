using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject Block;
    public GameObject BlockCoin;
    public int rnd;

    private void Start()
    {
        rnd = Random.Range(1, 11);
        if (rnd < 7)
        {
            Instantiate(Block, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(BlockCoin, transform.position, Quaternion.identity);
        }
    }
}
