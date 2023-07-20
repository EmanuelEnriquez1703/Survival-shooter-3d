using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRaycast : MonoBehaviour
{
    public GameObject obj;
    public float rayLength;
    public LayerMask layerRay;
    Ray ray; // el rayo
    RaycastHit raycastHit; // guarda la info del choque de raycast con el game object

    void Update()
    {
        // configuracion del rayo
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if(Physics.Raycast(ray, out raycastHit,rayLength , layerRay)) 
        // lanzado el rayo devuelve true si el rayo esta chocando con algo sino false
        {
            obj = raycastHit.collider.gameObject;
            Debug.Log("estoy chocadando con " + raycastHit.collider.name);
        }
        else Debug.Log("no estoy chocando con nada");
        Debug.DrawRay(ray.origin,ray.direction * rayLength , Color.red);

    }

}
