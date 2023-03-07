using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{

    [SerializeField]
    public int coinsCount;
    public Text coinsCountText;
    public int contentCurrentIndex = 0;
    public static Inventory instance;
    


    public List<Item> content = new List<Item>();
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de inventory dans la scène");
            return;
        }

        instance = this;
    }


    //Fonction pour ajouter des pièces à un compteur et mettre à jour le visuel du compteur
    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }

    //Mettre à jour la bourse en enlevant les pièces du niveau et en mettant à jour le visuel
    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();

    }

    public void GetNextItem()
    {
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = contentCurrentIndex - 1;
        }
    }

    public void GetPreviousItem()
    {
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = 0;
        }
    }

    public void ConsumeItem()
    {
        float currentPlayerMove = PlayerMovement.instance.moveSpeed;

        int currentPlayerHealth = PlayerHealth.instance.currentHealth;
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.TakeHeal(currentItem.hpGiven);
        PlayerMovement.instance.moveSpeed += currentItem.speedGive;
        if(currentPlayerMove != PlayerMovement.instance.moveSpeed || currentPlayerHealth != PlayerHealth.instance.currentHealth)
        {
            print(currentPlayerHealth + " = ? " + PlayerHealth.instance.currentHealth);
            print(currentPlayerMove + " = ? " + PlayerMovement.instance.moveSpeed);
            content.Remove(currentItem);
            GetPreviousItem();
        }
        else
        {
            print("Les states sont les mêmes");


        }

    }

}
