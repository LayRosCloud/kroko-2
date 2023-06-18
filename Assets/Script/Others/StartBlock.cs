using UnityEngine;
using UnityEngine.UI;

public class StartBlock : MonoBehaviour
{
    public Text StartTime;
    public int lifetimeint;
    public float lifetime;
    public bool Raz = false;


    private void Update()
    {
        if (Raz)
        {
            Destroy(gameObject, lifetime);
            lifetimeint = (int)lifetime;
            lifetime -= Time.deltaTime;
            StartTime.text = lifetimeint.ToString();
            Destroy(StartTime, lifetime);
        }
    }

}
