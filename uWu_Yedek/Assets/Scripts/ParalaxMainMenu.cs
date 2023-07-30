using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMainMenu : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _movespeed;
    

    
    void Update()
    {
 
        transform.Translate(-1 * _movespeed * Time.deltaTime, 0f, 0f);
        if (_cam.position.x >= transform.position.x + 18f)
        {
            transform.position = new Vector2
                (
                    _cam.position.x + 18f,
                    transform.position.y
                );
        }
        

    }
}
