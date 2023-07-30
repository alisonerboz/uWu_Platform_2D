using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeklemeSuresi : MonoBehaviour
{
    public float cooldownTime = 2;
    public float nextFireTime = 0;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Time.time> nextFireTime) {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Yetenek kullanýldý, bekleme süresi baþladý");
                nextFireTime = Time.time + cooldownTime;

            }
        }
        
    }
}
