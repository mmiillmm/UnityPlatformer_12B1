using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 15f;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(new Vector2(
            x: transform.rotation.z == 0 ? 1 : -1,
            y: 0) * _projectileSpeed, ForceMode2D.Impulse);
    }
}
