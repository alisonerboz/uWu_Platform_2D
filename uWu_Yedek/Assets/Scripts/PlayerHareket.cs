using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHareket : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;
    [SerializeField] private Vector2[] checkpoints;
    public static Vector2 lastTransform;
    private Rigidbody2D body;
    bool isSliding;
    public bool isDead = false;

    public float dashForce;
    public float startDashTime;

    float dashDirection;
    float currentDashTimer;

    public bool isGrounded = false;
    bool isDashing;

    private Animator anim;

    bool dashAvayebilebýl=false;
    public GameObject checkpoint;
    public void Awake()
    {

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin") || collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
            

        }
        else
            isGrounded = false;

    }

    public void OnCollisionExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            isGrounded = false;
        }
            
        Debug.Log("ayrýldý");
    }
    public void Start()
    {
        transform.position = lastTransform;
    }

    public void Update()
    {
        if(!isGrounded)
        {
            Debug.Log("zeminde deðil");
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        anim.SetBool("yuru", horizontalInput != 0);
        //SAÐ SOL YAP


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded==true)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
            }
            isGrounded = false;
            Debug.Log("zýpladý zeminde deðil");

        }

        if (Input.GetKeyUp(KeyCode.LeftShift)&&dashAvayebilebýl==true)
        {
            isDashing = true;
            currentDashTimer = startDashTime;
            body.velocity = Vector2.zero;
            dashDirection = (int)horizontalInput;

        }
        if (isDashing)
        {
            body.velocity = transform.right * dashDirection * dashForce;
            currentDashTimer -= Time.deltaTime;
            if (currentDashTimer <= 0)
            {
                isDashing = false;
            }
        }
        anim.SetBool("dash", isDashing);



        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }



    }

    private void FixedUpdate()
    {
        if(DiyalogManager.GetInstance().diyalogPlaying)
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            this.transform.parent = collision.transform;
            isGrounded = true;

        }
        if(collision.gameObject.tag=="checkpoint")
        {
            dashAvayebilebýl = true;
            Destroy(checkpoint);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            this.transform.parent = null;
        }
  



    }
    
}
