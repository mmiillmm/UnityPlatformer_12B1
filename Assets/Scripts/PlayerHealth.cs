using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] private GameObject bloodDropsFX;
    [SerializeField] private float dmgImmunityRate = .5f;

    private float currentHealth;
    private float nextDamage;

    private void Start()
    {
        currentHealth = maxHealth;
        nextDamage = 0f;
    }

    public void TakeDamage(float damage)
    {
        if (nextDamage < Time.time)
        {
            nextDamage = Time.time + dmgImmunityRate;
            Instantiate(bloodDropsFX, transform.position, bloodDropsFX.transform.localRotation);
            currentHealth -= damage;

            if (currentHealth <= 0) MakeDeath();
        }
    }

    private void MakeDeath()
    {
        Destroy(gameObject);
    }
}
