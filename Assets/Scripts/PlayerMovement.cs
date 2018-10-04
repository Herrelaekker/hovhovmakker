using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeedStart;
    public float moveSpeed;
    private Rigidbody2D rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public bool knockFromTop;

    // Use this for initialization
    void Start()
    {
        moveSpeed = moveSpeedStart;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = moveInput * moveSpeed;

        if (knockbackCount <= 0)
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        else
        {
            if (knockFromRight && knockFromTop)
                moveInput = new Vector3(-knockback, -knockback);
            else if (!knockFromRight && knockFromTop)
                moveInput = new Vector3(knockback, -knockback);
            else if (knockFromRight && !knockFromTop)
                moveInput = new Vector3(-knockback, knockback);
            else if (!knockFromRight && !knockFromTop)
                moveInput = new Vector3(knockback, knockback);

            knockbackCount -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

}
