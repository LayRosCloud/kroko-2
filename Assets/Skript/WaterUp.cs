using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterUp : MonoBehaviour
{
    [SerializeField] private Transform _water;
    
    private Coroutine _coroutine;
    public bool IsStartGame = false;
    private void Update()
    {
        if (_coroutine != null || IsStartGame == false)
        {
            return;
        }
        _coroutine = StartCoroutine(TryWaterChallenge());
    }

    private IEnumerator TryWaterChallenge()
    {
        yield return new WaitForSeconds(10f);
        int number = Random.Range(0, 100);
        
        if (number < 40)
        {
            for (float i = 1; i <= 8; i+=0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                var waterLocalScale = _water.localScale;
                waterLocalScale.y = i;
                _water.localScale = waterLocalScale;
            }

            yield return new WaitForSeconds(5f);
            
            for (float i = _water.localScale.y; i >= 1; i-=0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                var waterLocalScale = _water.localScale;
                waterLocalScale.y = i;
                _water.localScale = waterLocalScale;
            }
        }

        _coroutine = null;
    }
}
