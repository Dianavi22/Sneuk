using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healOnCollision = 10;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            //vérif si l'objet peut être pris

            if(PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAt(pickupSound, transform.position);
                PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
                playerHealth.TakeHeal(healOnCollision);
                Debug.Log("miam !");
                Destroy(gameObject);
            }
            else
            {
                //Afficher que le joueur ne peut pas prendre l'item puisque sa barre de vie est pleine

                Global.GlobalVariables.interactUI.text = "VOUS ETES FULL LIFE !";
                Global.GlobalVariables.interactUI.enabled = true;
            }

            

        }
    }


}
