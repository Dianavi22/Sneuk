using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    public int coinValue;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {

//On vérifie si la collision est bien avec le joueur
        if (collision.CompareTag("Player"))
        {
            //jouer le sound effect
            AudioManager.instance.PlayClipAt(sound, transform.position);
            //On ajoute 1 à l'inventaire
            Inventory.instance.AddCoins(coinValue);
            //On ajoute l'objet comme étant un objet de la scène en question et que le player l'a sur lui (s'il meure il n'aura plus cette pièce)
            CurrentSceneManager.instance.coinsPickedInThisScene++;
            //on détruit l'objet de la scène
            Destroy(gameObject);
        }
    }

}
