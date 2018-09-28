using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeedStart;
    public float moveSpeed;
    private Rigidbody2D rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    // Use this for initialization
    void Start()
    {
        moveSpeed = moveSpeedStart;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        moveVelocity = moveInput * moveSpeed;

    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;

    }

}
