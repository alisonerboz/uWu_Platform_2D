using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D body;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction = 0;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    
    void Update()
    {
        if (direction == 0)
        {
            if (transform.localScale.x == -1 && Input.GetKeyDown(KeyCode.E))
            {
                direction = 1;
                Debug.Log("dash");
            }
            else if (transform.localScale.x == 1 && Input.GetKeyDown(KeyCode.E))
            {
                direction = 2;
                Debug.Log("dash");
            }

        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                body.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    body.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    body.velocity = Vector2.right * dashSpeed;
                }

            }

        }
    }
}
