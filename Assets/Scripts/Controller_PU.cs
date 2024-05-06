using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PU : MonoBehaviour
{
    public static float buffVelocity;
    private Rigidbody rb;
    public static bool picked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //reguardamos el rigid body del enemigo igual que con el jugador
    }

    void Update()
    {
        //con cada update añadimos mas fuera al objeto hacia la izquierda, haciendo que acelere de a poco
        rb.AddForce(new Vector3(-buffVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
        Picked();
    }

    public void Picked()
    {
        if (picked)
        {
            picked = false;
            Time.timeScale = 2;
            Destroy(this.gameObject);            
        }
    }

    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15) //si la posicion del enemigo sale del limite (-15 en X)
        {
            Destroy(this.gameObject); //lo destruimos para ahorrar memoria 
        }
    }

}
