using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDestroyed : MonoBehaviour
{
    public float dieTime;
  
    void Start()
    {
        StartCoroutine(Timer());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        if(collisionGameObject.name == "Circle")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
