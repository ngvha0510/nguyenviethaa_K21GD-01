using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;
    private Transform hoisinh;
    public AudioSource aus;
    public AudioClip click;

    SaveLoad playerdata;

    private void Awake()
    {
        playerdata = FindObjectOfType<SaveLoad>();
        playerdata.PlayerPosLoad();
    }


    private bool doubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            aus.PlayOneShot(click);
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
                //aus.PlayOneShot(click);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("diemhoisinh"))
        {
         
            hoisinh = collision.transform;
        }

        if (collision.CompareTag("Bay"))
        {
            
            transform.position = hoisinh.position;
           
        }
    }
}
