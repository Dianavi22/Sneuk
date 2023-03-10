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
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(sellButtonPrefab, sellButtonsParent);
        }
     }
    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }

    
}
