using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathCanvas;
    private bool _isDead;

    public bool IsDead => _isDead;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kislota"))
        {
            Die();
            _deathCanvas.SetActive(true);
            PlayerEvents.Instance.DeathEvent.Invoke();
        }
    }

    public void Die()
    {
        _isDead = true;
    }

    public void Heal()
    {
        _isDead = false;
    }
}
