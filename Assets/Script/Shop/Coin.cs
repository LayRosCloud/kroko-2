using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private int _cost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int oldMoney = PlayerPrefs.GetInt("Coin", 0);
            PlayerPrefs.SetInt("Coin", oldMoney + _cost);

            Destroy(gameObject);
            DisplayEvents.AddMoney.Invoke(oldMoney + _cost);
        }
    }
}
    