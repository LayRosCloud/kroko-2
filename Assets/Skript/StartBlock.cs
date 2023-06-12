using UnityEngine;
using UnityEngine.UI;

public class StartBlock : MonoBehaviour
{
    public float lifetime;
    public Text StartTime;
    public int lifetimeint;
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
