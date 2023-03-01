using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }
    public void OnPlayerDeath()
    {
         gameOverUI.SetActive(true);    
    }

    //recommencer le niveau
    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedInThisScene);
        //recharger la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //replacer le joueur au  spawn
        PlayerHealth.instance.Respawn();
        //Réactiver les mouvements du joueur + lui rendre de la vie
        gameOverUI.SetActive(false);
    }

    //retourner au menu principal
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //quitter le jeu
    public void QuitButton()
    {
        Application.Quit();
    }


}
