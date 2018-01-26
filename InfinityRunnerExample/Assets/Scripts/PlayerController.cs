using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int jumpForce = 230;
    private const float groundCheckRadius = 0.2f;
    private const float slideTime = 1f;

    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private GameObject groundCheck;
    private GameObject colisor;

    private float timer;
    private bool isOnGround = false;
    private bool slide = false;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        groundCheck = GameObject.Find("GroundCheck");
        colisor = GameObject.Find("Colisor");
        Debug.Log("Player Started.");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            if (slide == true)
            {
                colisor.transform.position = new Vector3(colisor.transform.position.x,
                    colisor.transform.position.y + 0.3f, colisor.transform.position.z);
                slide = false;
            }
        }

        if (Input.GetButtonDown("Slide") && isOnGround && !slide)
        {
            colisor.transform.position = new Vector3(colisor.transform.position.x,
                colisor.transform.position.y - 0.3f, colisor.transform.position.z);
            slide = true;
            timer = 0f;
        }

        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, 0.2f, groundLayer);

        if (slide == true)
        {
            timer += Time.deltaTime;

            if (timer >= slideTime)
            {
                colisor.transform.position = new Vector3(colisor.transform.position.x,
                    colisor.transform.position.y + 0.3f, colisor.transform.position.z);
                slide = false;
            }
        }

        playerAnimator.SetBool("jump", !isOnGround);
        playerAnimator.SetBool("slide", slide);
    }

    private void OnTriggerEnter2D()
    {
        Debug.Log("bateu");
    }
}
