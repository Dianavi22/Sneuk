using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Animator animator;
    public Text pnjNameText;
    public GameObject sellButtonPrefab;
    public Transform sellButtonsParent;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }

        instance = this;
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        pnjNameText.text = pnjName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen", true);
    }

     void UpdateItemsToSell(Item[] items)
     {
        //Supprime les boutons présents dans le parent
        for (int i = 0; i < sellButtonsParent.childCount; i++)
        {
            print("JE SUPPRIME");
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }

        //Instancie un bouton à chaque item à vendre et le configure
        for (int i = 0; i < items.Length; i++)
        {
            print("J'INSTANCIE");

            GameObject button =  Instantiate(sellButtonPrefab, sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = items[i].name;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();

            buttonScript.item = items[i];
            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); });
        }
     }
    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }

    
}
