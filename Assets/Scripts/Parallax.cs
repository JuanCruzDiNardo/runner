using UnityEngine;

public class Parallax : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect ; // variable seteada desde Unity, esta determina la velocidad de cada imagen de fondo
                                 // se establecen distintas velocidades en cada imagen (menor mientras mas lejos esta) para cerar el efecto de parallax   
    void Start()
    {
        startPos = transform.position.x; //guardamos la posicion original de eje X //revisando de nuevo creo que esta variable tampoco se usa o no supe encontrar donde
        length = GetComponent<SpriteRenderer>().bounds.size.x; //esta variable no se usa, pero guarda el largo de la imagen en X si no me equivoco
        parallaxEffect /= 2;
    }

    void Update()
    {
        if (!gameOver)
        {
            //en cada update le restamos el valor de la variable de velocidad para desplazar la imagen hacia la izquierda
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
            if (transform.localPosition.x < -20) //establecemos -20 como el limite de posicion en X
            {
                //establecemos al posicion de la imagen en 20 para "mandarla adelante" de nuevo
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
