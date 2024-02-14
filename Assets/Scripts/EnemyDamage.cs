using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    [SerializeField] private float pushForce = 20f;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            PushBack(player.transform);
        }
    }

    private void PushBack(Transform playerTransform)
    {
        Rigidbody2D playerRigidbody = playerTransform.gameObject.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(new Vector2(0, 1) * pushForce, ForceMode2D.Impulse);
    }
}
