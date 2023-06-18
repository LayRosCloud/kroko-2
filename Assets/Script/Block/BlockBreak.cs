using System.Collections;
using UnityEngine;

public class BlockBreak : Block
{
    [SerializeField] private GameObject _breakable;
    
    protected override void EnterPlayer()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifetime);
        GameObject gm = Instantiate(_breakable);
        gm.transform.position = transform.position;
        Destroy(gm, 5f);
        Destroy(gameObject);
    }
    
}
