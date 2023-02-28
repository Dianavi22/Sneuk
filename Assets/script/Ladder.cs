using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{

    private bool isInRange; //être à porté
    private PlayerMovement playerMovement; 
    public BoxCollider2D topCollider;
    public Text interactUI;
    


    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        // Sortir de l'échelle

        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }
        //avec la manette
        if (isInRange && playerMovement.isClimbing && Input.GetButtonDown("B"))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        // Entrer dans l'échelle

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
        //avec la manette
        if (isInRange && Input.GetButtonDown("Y"))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Global.GlobalVariables.interactUI.text = "VOUS POUVEZ UTILISER FACILEMENT CETTE ECHELLE";
            Global.GlobalVariables.interactUI.enabled = true;
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        playerMovement.isClimbing = false;
        topCollider.isTrigger = false;
        Global.GlobalVariables.interactUI.enabled = false;
    }
}
