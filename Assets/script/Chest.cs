using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
    private bool isInRange;
    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundToPlay;
    [SerializeField] Text interactUI;

    void Awake()
    {
       

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
        interactUI.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;

            interactUI.text = "OUVRIR LE COFFRE";

            isInRange = true;
            print(isInRange);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       interactUI.enabled = false;

        isInRange = false;

    }
}
