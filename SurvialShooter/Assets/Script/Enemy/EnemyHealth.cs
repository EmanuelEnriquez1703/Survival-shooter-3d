using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /*salud enemigo*/
    public int maxHealth; // maxima salud del enemigo
    public int curretHealth; // salud actual
    public float sinkSpeed; // valocidad de undimiento del enemy
    public int scoreValue; // puntos 
    public bool isDead; // si esta muerto el enemigo
    Animator anim;
    bool isSinking; // si el enemigo se esta hundiendo

    void Start()
    {
        curretHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isSinking == true)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

  
    // esta funcion es publica por la vamos a llamar desde playerShooting.cs
    public void TakeDamage(int amout)
    {
        // si isDeas es true me salgo de la funcion porque ya esta muerto
        if(isDead) return;

        curretHealth -= amout;

        if(curretHealth <= 0) Death();
    }

    void Death()
    {
        isDead = true;
        // Destroy(gameObject);
        anim.SetTrigger("Death");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Score(scoreValue);
    }
    // metodo public que voy a llmar desde la animacion de death
    public void StartSinking()
    {
        isSinking = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        Destroy(gameObject,2);
    }
}
