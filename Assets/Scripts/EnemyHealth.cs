using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject deathFX;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        healthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0) KillMe();
    }

    private void KillMe()
    {
        Instantiate(deathFX, transform.position, deathFX.transform.localRotation);
        if (gameObject.transform.parent == null) Destroy(gameObject);
        else Destroy(gameObject.transform.parent.gameObject);
    }
}
