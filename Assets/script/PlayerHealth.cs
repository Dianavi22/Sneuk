using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]

    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvicible = false;
    public bool isHealing = false;

    public float InvicibilityFlashDelay = 0.15f;
    public float InvicibilityTimeAfterHit = 2f;

    public float HealingFlashDelay = 0.15f;
    public float HealingTimeAfterPotion = 1f;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public AudioClip hitSound;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de playerHealth dans la scène");
            return;
        }

        instance = this;
    }
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        //Pouvoir faire du damage ou du heal pour les tests
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(90);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeHeal(20);
        }

    }


    //Fonction qui donne des dégâts au joueur
    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);

            currentHealth -= damage;

            //Si le joueur est à moins de 0 PV on remet ses PV à 0 (il ne peut pas avoir des PV négatifs)
            if (currentHealth <= 0)
            {
                currentHealth = 0;
              
            }
            healthBar.SetHealth(currentHealth);
            
            //vérifier si le joueur est toujours vivant
            if(currentHealth <= 0)
            {
                //lancement de la fonction Death
                Death();
                return;
            }
            //sinon le joueur est temporairement invincible 
            isInvicible = true;
            StartCoroutine(InvibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }

    }

    //Fonction de la mort du player
    public void Death()
    {

        // Bloquer les mouvements du personnage
        PlayerMovement.instance.enabled = false;
        // jouer l'animation d'élimination
        PlayerMovement.instance.animator.SetTrigger("Death");
        // Empêcher les interractions physiques avec les autres éléments
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        //Pour éviter que la caméra nous suive
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    //Fonction de Respawn
    public void Respawn()
    {

        //Rendre au player ses mouvements
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        //faire en sorte que le player puisse interragir avec son environnement
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        //lui rendre tous ses PV et mettre à jour le visuel
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }



    //Fonction de heal du player
    public void TakeHeal(int heal)
    {
        if (!isHealing)
        {

            currentHealth += heal;
            //le joueur ne peut pas avoir de heal si sa vie est au max
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            //mettre à jour le visuel
            healthBar.SetHealth(currentHealth);
            //jouer l'animation de heal
            isHealing = true;
            StartCoroutine(HealUpFlash());
            StartCoroutine(HandleHealingDelay());
        }

    }

    //Animation de damage (lorsque le player est invincible)
    public IEnumerator InvibilityFlash()
   
        {
        while (isInvicible)
        {
            //on alterne des couleurs 
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvicibilityFlashDelay);

        }

    }


    public IEnumerator HealUpFlash()

    {
        while (isHealing)
        {
            //on alterne des couleurs 
            graphics.color = new Color(1f, 0.34f, 1f, 1f);
            yield return new WaitForSeconds(HealingFlashDelay);
           graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(HealingFlashDelay);

        }

    }

    //Le personnage n'est plus invincible
    public IEnumerator HandleInvicibilityDelay()
    {

        yield return new WaitForSeconds(InvicibilityTimeAfterHit);
        isInvicible = false;

    }

    //le personnage n'est plus en train de se heal
    public IEnumerator HandleHealingDelay()
    {
        yield return new WaitForSeconds(HealingTimeAfterPotion);
        isHealing = false;
    }

}

