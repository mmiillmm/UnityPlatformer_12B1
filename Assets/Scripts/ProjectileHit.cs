using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    [SerializeField] private GameObject exlposionEffect;
    [SerializeField] private float damage = 1f;

    private ProjectileController controller;

    private void Awake()
    {
        controller = GetComponentInParent<ProjectileController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Destroyable"))
        {
            controller.StopMove();
            Instantiate(exlposionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
