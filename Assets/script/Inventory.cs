using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

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
        coinsCountText.text = coinsCount.ToString();
    }

    //Mettre à jour la bourse en enlevant les pièces du niveau et en mettant à jour le visuel
    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }

}
