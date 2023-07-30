using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject bullet;

    public GameObject tunel;
    public GameObject kap�;

    private Animator anim;
    private void Start()
    {
        isShooting = false;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1")&& !isShooting)
        {

            StartCoroutine(Shoot());
            
        }
        
    }
    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        isShooting = true;
        
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed *direction(), 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="kap�")
        {
            
            Destroy(tunel);
            Destroy(kap�);
        }
    }

}
