using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] private GameObject bloodDropsFX;
    [SerializeField] private float dmgImmunityRate = .5f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image bloodScreen;
    [SerializeField] private float smoothColor = 2f;

    private float currentHealth;
    private float nextDamage;
    private bool isDamaged;

    private void Start()
    {
        currentHealth = maxHealth;
        nextDamage = 0f;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void Update()
    {
        if (isDamaged)
        {
            bloodScreen.color = new(255, 255, 255, 0.8f);
        }

        else
        {
            bloodScreen.color = Color.Lerp(
                bloodScreen.color,
                new(255, 255, 255, 0f),
                Time.deltaTime * smoothColor);
        }

        isDamaged = false;

    }

    public void TakeDamage(float damage)
    {
        if (nextDamage < Time.time)
        {
            nextDamage = Time.time + dmgImmunityRate;
            Instantiate(bloodDropsFX, transform.position, bloodDropsFX.transform.localRotation);
            currentHealth -= damage;
            isDamaged = true;

            healthBar.value = currentHealth;


            if (currentHealth <= 0) MakeDeath();
        }
    }

    private void MakeDeath()
    {
        Destroy(gameObject);
        bloodScreen.color = new(255, 255, 255, 1f);
    }
}
