using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    public static bool parried = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //reguardamos el rigid body del enemigo igual que con el jugador
    }

    void Update()
    {
        //con cada update añadimos mas fuera al objeto hacia la izquierda, haciendo que acelere de a poco
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force); 
        OutOfBounds();
        Parried();
        
    }

    public void Parried()
    {        
        if (parried)
        {
            parried = false;
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
