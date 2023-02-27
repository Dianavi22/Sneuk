using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField]
    private Transform playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //on compare si la collision s'est faite avec un tag player
        if(collision.CompareTag("Player"))
        {

            //on fait passer le player spawn aux nouvelles positions et on détruit les anciennes
            playerSpawn.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
