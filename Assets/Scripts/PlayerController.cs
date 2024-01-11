using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 7;

    private Animator animator;
    private Rigidbody2D rigidbody2d;

    private bool isFacingRight;

    private void Start()
    {
        isFacingRight = true;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new(
            x: move * maxSpeed,
            y: rigidbody2d.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(move));
        if ((move > 0 && !isFacingRight) || (move < 0 && isFacingRight)) Flip();
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.localScale = new(
            x: transform.localScale.x * -1,
            y: transform.localScale.y);
    }
}
