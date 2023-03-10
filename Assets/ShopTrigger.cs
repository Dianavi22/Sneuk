using UnityEngine.UI;

using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] Text interactUI;
    public bool isInRange;
    public string pnjname;
    public Item[] itemsToSell;

    private void Awake()
    {
        Global.GlobalVariables.Text = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) ShopManager.instance.OpenShop(itemsToSell, pnjname);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
            interactUI.text = "ACHETER DES MARCHANDISES";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            interactUI.text = "";
        }
       ShopManager.instance.CloseShop();
    }
}
