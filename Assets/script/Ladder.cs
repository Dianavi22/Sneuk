using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    [SerializeField] Text interactUI;

    private bool isInRange; //être à porté
    private PlayerMovement playerMovement; 
    public BoxCollider2D topCollider;
    


    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Global.GlobalVariables.Text = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
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
            print("Player collided");
            interactUI.enabled = true;
            interactUI.text = "VOUS POUVEZ UTILISER FACILEMENT CETTE ECHELLE";
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        playerMovement.isClimbing = false;
        topCollider.isTrigger = false;
        interactUI.enabled = false;
    }
}
