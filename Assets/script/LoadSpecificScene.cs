using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadSpecificScene : MonoBehaviour
{
    public AudioClip jingleAchievement;
    public string sceneName;
    public Animator fadeSystem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
   //On compare dans la collision si le Tag est bien celui du Player
        if (collision.CompareTag("Player"))
        {
           
            StartCoroutine(loadNextScene());
        }   
    }

    // Méthode qui charge la scène suivante
    public IEnumerator loadNextScene()
    {
        AudioManager.instance.PlayClipAt(jingleAchievement, transform.position);
        //Jouer l'animation de fondue au noir + Changer de scène
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
