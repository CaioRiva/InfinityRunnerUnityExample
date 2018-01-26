using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int jumpForce = 230;
    private const float groundCheckRadius = 0.2f;
    private const float slideTime = 1f;

    public static int score;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip slideSound;
    [SerializeField]
    private UnityEngine.UI.Text scoreTxt;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private GameObject groundCheck;
    private GameObject colisor;
    private AudioSource audio;
    

    private float timer;
    private bool isOnGround = false;
    private bool slide = false;

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        groundCheck = GameObject.Find("GroundCheck");
        colisor = GameObject.Find("Colisor");
        audio = GetComponent<AudioSource>();
        Debug.Log("Player Started.");
    }

    void Update()
    {
        scoreTxt.text = score.ToString(); 

        if (Input.GetMouseButtonDown(0) && isOnGround)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            audio.PlayOneShot(jumpSound);
            audio.volume = 1f;

            if (slide == true)
            {
                colisor.transform.position = new Vector3(colisor.transform.position.x,
                    colisor.transform.position.y + 0.3f, colisor.transform.position.z);
                slide = false;
            }
        }

        if (Input.GetMouseButtonDown(1) && isOnGround && !slide)
        {
            audio.PlayOneShot(slideSound);
            audio.volume = 0.5f;
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
        PlayerPrefs.SetInt("score", score);
        if(score > PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", score);
        }
        Application.LoadLevel("gameOver");
    }
}
