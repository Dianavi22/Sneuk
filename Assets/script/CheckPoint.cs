using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField]

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //on compare si la collision s'est faite avec un tag player
        if(collision.CompareTag("Player"))
        {

            //on fait passer le player spawn aux nouvelles positions et on détruit les anciennes
            CurrentSceneManager.instance.respawnPoint = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
