using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovent : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agenet;
    Animator anim;
    EnemyHealth enemyHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agenet = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && enemyHealth.isDead == false) 
        {
            agenet.SetDestination(player.transform.position);
        }
        Animating();
    }

    void Animating()
    {
        if (agenet.velocity.magnitude != 0) anim.SetBool("isMoving", true);
        else anim.SetBool("isMoving", false);
    }
}
