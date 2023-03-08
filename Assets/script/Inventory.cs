using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{

    [SerializeField]
    public int coinsCount;
    public Text coinsCountText;
    private int contentCurrentIndex = 0;
    public static Inventory instance;
    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemNameUI;
    public PlayerEffect playerEffect;
    


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

    private void Update()
    {
        UpdateInventoryUI();
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
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = contentCurrentIndex - 1;
        }
        UpdateInventoryUI();

    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;

        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemNameUI.text = "";
            itemImageUI.sprite = emptyItemImage;
        }
    }

    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        float currentPlayerMove = PlayerMovement.instance.moveSpeed;

        int currentPlayerHealth = PlayerHealth.instance.currentHealth;
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.TakeHeal(currentItem.hpGiven);
        playerEffect.AddSpeed(currentItem.speedGive, currentItem.speedDuration);
        if(currentPlayerMove != PlayerMovement.instance.moveSpeed || currentPlayerHealth != PlayerHealth.instance.currentHealth)
        {
            content.Remove(currentItem);
            GetPreviousItem();
        }
        else
        {

        }

    }

}
