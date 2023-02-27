using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPotion : MonoBehaviour
{
    public int damageOnCollision = 80;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Prendre l'objet obligatoirement

                PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damageOnCollision);
                Destroy(gameObject);
        }
    }
}
