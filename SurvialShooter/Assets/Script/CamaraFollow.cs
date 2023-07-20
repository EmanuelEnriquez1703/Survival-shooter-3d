using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
   
    public Transform player;
    public float smoothing; // velocidad de seguimiento
    Vector3 offset; // distancia inicial entre camara y player
    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // calculo la posicion a la quiero mover la camara
        Vector3 targetCamPos = player.position + offset;

        transform.position = Vector3.Lerp(transform.position,targetCamPos, smoothing * Time.deltaTime);
    }
}
