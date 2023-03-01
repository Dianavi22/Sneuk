using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
   // public Text interactUI;
    private bool isInRange;
    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundToPlay;

    void Awake()
    {
        //Global.GlobalVariables.interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        Global.GlobalVariables.interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent(typeof(Text)) as Text;

        print(Global.GlobalVariables.interactUI);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange == true) OpenChest();
    }
    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        Global.GlobalVariables.interactUI.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Global.GlobalVariables.interactUI.text = "OUVRIR LE COFFRE";
            Global.GlobalVariables.interactUI.enabled = true;

            isInRange = true;
            print(isInRange);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Global.GlobalVariables.interactUI.enabled = false;

        isInRange = false;

    }
}
