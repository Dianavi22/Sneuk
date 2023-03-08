using UnityEngine;
using UnityEngine.UI;


public class PickUpItem : MonoBehaviour
{
    private bool isInRange;
    public AudioClip soundToPlay;
    [SerializeField] Text interactUI;
    public Item item;

    void Awake()
    {


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange == true) TakeItem();
    }
    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;

            interactUI.text = "TAKE ITEM";

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

