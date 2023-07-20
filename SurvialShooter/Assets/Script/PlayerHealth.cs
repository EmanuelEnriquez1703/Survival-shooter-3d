using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float curretHealth;
    public Slider slider;
    public Image damegeImage; 
    public Image healthImage; // corazon que tenemos en la interfaz
    public float flashSpeed; // la velocidad a la que va a desaparecer la img
    public Color flashColur; // el color de img
    public GameManager gameManager;

    Animator anim;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    
    bool isDead;
    bool demaged;
    void Start()
    {
        curretHealth = maxHealth;    
        slider.maxValue = maxHealth;
        slider.value = maxHealth; 
        healthImage.fillAmount = 1;

        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }

    void Update()
    {
        if(demaged)
        {
            damegeImage.color  = flashColur;
        }else
        {
            damegeImage.color = Color.Lerp(damegeImage.color,Color.clear,flashSpeed * Time.deltaTime);
        }

        demaged = false;
    }
    // la funcion va a hacer llamada desde el script del enemigo
    public void TakeDamage(int amout)
    {
        if(isDead == true) return; // si el player ha muerto se sale de la funcion 
        demaged = true;
        curretHealth -=amout;
        slider.value = curretHealth;
        if(curretHealth <= 0) Death();

        healthImage.fillAmount = curretHealth / maxHealth;
    }
    void Death()
    {
        isDead = true;
        anim.SetTrigger("Death");
        // desavilitamos los componentes para que el player no pueda moverse ni disparar
        playerMovement.enabled = false;
        playerMovement.enabled = false;
    }
    // funcion publica que va como evento en la animacion 
    public void DeathComplete()
    {
        gameManager.GameOver();
    }
}
