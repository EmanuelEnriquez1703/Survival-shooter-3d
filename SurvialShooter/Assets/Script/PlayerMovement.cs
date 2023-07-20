using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // velocidad de movimento
    public int speed;
    float horizontal;
    float vertical;

    public LayerMask layerFloor; // la capa donde va estar en suelo de la escena
    Rigidbody rigiBody;
    Vector3 movement; // vamos a guardar la direccion de movimiento
    Animator anim;
    // movimientos del gugador
    

    void Start()
    {   
        rigiBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();        
    }

    void Update()
    {
        InputPlayer();
    }

    void FixedUpdate()
    {
        movementPlayer();
        Turning();
        Animating();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void movementPlayer()
    {
        movement = new Vector3(horizontal,0,vertical); // direccion de movimiento a travez de los inputs
        movement.Normalize(); // normalizo el vector es decir su modulo(longitud) vale 1
        rigiBody.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    void Turning()
    {
        // raycast que va desde el curso del mouse en coordenadas de pantalla y con direccion hacia la escena

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray , out hit , Mathf.Infinity , layerFloor))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;
            // calcula la rotacion
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            // aplicar rotacion
            rigiBody.MoveRotation(newRotation);
        }
        Debug.DrawRay(ray.origin,ray.direction * 1000,Color.yellow);
    }
    void Animating()
    {
        if(horizontal != 0 || vertical != 0) anim.SetBool("isMoving",true);
        else anim.SetBool("isMoving",false);
    }
}
