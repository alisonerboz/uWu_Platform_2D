using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _movespeed;
    

    
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(-1 * _movespeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(1 * _movespeed * Time.deltaTime, 0f, 0f);
        }
        if (_player.position.x >= transform.position.x + 60f)
        {
            transform.position = new Vector2
                (
                    _player.position.x + 60f,
                    transform.position.y
                );
        }
        if (_player.position.x <= transform.position.x - 60f)
        {
            transform.position = new Vector2
                (
                    _player.position.x - 60f,
                    transform.position.y
                );
        }

    }
}
