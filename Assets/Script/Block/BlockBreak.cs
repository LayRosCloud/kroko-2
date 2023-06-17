using System.Collections;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    [SerializeField] private GameObject _breakable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        GameObject gm = Instantiate(_breakable);
        gm.transform.position = transform.position;
        Destroy(gm, 5f);
        Destroy(gameObject);
    }


}
