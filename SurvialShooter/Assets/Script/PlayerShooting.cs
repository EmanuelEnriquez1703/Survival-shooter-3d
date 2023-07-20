using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int dangePerShot; // daño por disparo que va hacer al  player
    public float timeBetweenBullest; // time entre disparo
    public float rango; // longitud del raycast significa hasta que disancia puede disparar
    public LayerMask shootTablemask; // capa de obj que vamos a disparar 
    float timer; // contador de tiempo
    float effectsDisplayTime = 0.2f; // variable que va a determinar cuanto tiempo los efectos van a estar pantalla
    Ray ray;
    RaycastHit hit; 
    LineRenderer line; 
    AudioSource audioSource;
    Light gunLigth;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        gunLigth = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //contador de tiempo 
        if(Input.GetKey(KeyCode.R) && timer >= timeBetweenBullest)
        {
            Shoot();
        }

        if(timer >= timeBetweenBullest * effectsDisplayTime)
        {
            line.enabled = false;
            gunLigth.enabled = false;
        }
    }
    void Shoot()
    {
        timer = 0;
        audioSource.Play();
        // habilitamos el componente lineRendere y Ligth 
        line.enabled = true;
        gunLigth.enabled = true;
        // establesco el primer punto del lineRenderer
        line.SetPosition(0,transform.position);

        ray.origin = transform.position;
        ray.direction = transform.forward;

        if(Physics.Raycast(ray, out hit,rango,shootTablemask))
        {
            // me guardo en una variable (local) el gameobject con el que estoy chocando
            GameObject _object = hit.collider.gameObject;
            // compruebo si ese gameobj es el enemigo

            if(_object.GetComponent<EnemyHealth>())
            {
                _object.GetComponent<EnemyHealth>().TakeDamage(dangePerShot);
            }
            // estoy estableciendo el segundo punto del line renderer
            line.SetPosition(1,hit.point);
        }
        else 
        {
            /* estoy estableciendo el segundo  punto del lineRenderer a una distancia desde el origen
            del raycast*/
            line.SetPosition(1,ray.origin + (ray.direction * rango));
        }
    }
}
