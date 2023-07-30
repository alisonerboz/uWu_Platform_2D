using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiyalogTrigger : MonoBehaviour
{
    [Header("Görsel")]
    [SerializeField] private GameObject gorsel;


    [Header("INK")]
    [SerializeField] private TextAsset inkle;

    private bool playerInRange;


    private void Awake()
    {
        playerInRange = false;
        gorsel.SetActive(false);
    }

    private void Update()
    {
        if(playerInRange && !DiyalogManager.GetInstance().diyalogPlaying)
        {
            gorsel.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                DiyalogManager.GetInstance().EnterDiyalogMode(inkle);
            }
        }
        else
        {
            gorsel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "player")
        {
            playerInRange = false;
        }
    }
}
