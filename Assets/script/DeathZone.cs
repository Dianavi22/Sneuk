using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField]
    private Animator fadeSystem;
    private void Awake()
    {
        //BUG
        //fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //On compare l'objet avec la collision de la deathZone t on voit si l'objet a le tag player
        if(collision.CompareTag("Player"))
        {
            //On appelle la coroutine qui va replacer le player 
            StartCoroutine(ReplacePlayer(collision));
            //On met à jour la barre de vie du joueur et son nombre de PV
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
        }
    }

    //Fonction qui replace le player au positions du playerSpawn
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;
    }

}
