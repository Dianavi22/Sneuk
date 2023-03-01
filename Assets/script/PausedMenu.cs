using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public static PausedMenu instance;
    public GameObject settingsWindow;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PausedMenu dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

        if (Input.GetButtonDown("StartButton"))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        //Activer menu pause / l'afficher
        pauseMenuUI.SetActive(true);
        //arrêter le temps
        Time.timeScale = 0;
        // changer le statut du jeu 
        gameIsPaused = true;
    }
    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        //Désactiver menu pause / l'effacer
        pauseMenuUI.SetActive(false);
        //réactiver le temps
        Time.timeScale = 1;
        // changer le statut du jeu 
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        
        Resume();
        SceneManager.LoadScene("MainMenu");
    }


    public void RestartButton()
    {
        Resume();
       
        //   Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedInThisScene);
        //   //recharger la scène
        //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //   //replacer le joueur au  spawn
        //   PlayerHealth.instance.RespawnBeforRestartButton();
        //   //Réactiver les mouvements du joueur + lui rendre de la vie
        //   GameOverManager.instance.gameOverUI.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        gameIsPaused = false;
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

}
