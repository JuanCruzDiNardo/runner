using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0; //esta variable podria llamarse "DuckCheck" y ser un bool, ya que solo se una como variable de control
    private bool floored;
    private bool parry = false;
    private float parrytime;
    private bool buffed;
    public static float buffedtime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //adquirimos el rigidbody del objeto al cual le apliquemos el script (en este caso el jugador) y lo guardamos en una variable para referenciarlo
        initialSize = rb.transform.localScale.y; //guardamos el valor inicial de la altura
    }

    void Update() //en cada update llamamos a la funcion GetInput
    {
        GetInput(); 
    }

    private void GetInput() //GetImput lama a las otras dos funciones en cada update
    {
        Jump();
        Duck();
        Parry();
        Buffed();
    }

    private void Buffed()
    {
        if (buffed)
        {
            buffedtime -= Time.deltaTime;

            if (buffedtime <= 0 )
            {
                buffed = false;
                Time.timeScale = 1;
                buffedtime = 0;
            }
        }
    }

    private void Parry()
    {
        parrytime -= Time.deltaTime;
        
        if (parrytime < 0)
        {
            parrytime = 2;
            parry = false;
        }

        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                parry = true;                
            }
        }
    }

    private void Jump()
    {
        if (floored) //Comprueba si la variable "floored" es true para determinar si el jugador se encuentra en el piso
        {
            if (Input.GetKeyDown(KeyCode.W)) //comprueba que la tecla pulsada sea la "W"
            {
                //la aplica al rigid body una fuerza solo en el eje Y que es igual al valor de JumpForce
                //el Vector3 indica un vector de 3 dimenciones con X y Z en 0 e Y con la fueza de salto, para solo desplazarlo en le eje vertical
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);                
            }
        }
    }

    private void Duck()
    {
        if (floored) //comprueba si "floored" es true 
        {
            if (Input.GetKey(KeyCode.S)) //comprueba que la tecla pulsada sea la "S"
            {
                if (i == 0) // compruba si i es 0
                {
                    //trasforma las dimensiones del rb, pasando como parametro el mismo largo y ancho pero la mitad de su propia altura
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++; //aumenta i en 1 para evitar que el reescalado se de mas de una vez
                }
            }
            else //si no se presiono la S se ejecuta este bloque (no es necesario que se presione otra tecla, en cada update donde no se presione 
            {
                if (rb.transform.localScale.y != initialSize) //checkea si el tamaño actual de la altura no es igual a su valor original
                {
                    //igualamos la altura a su valor orginar de la misma forma en la que lo redujimos antes
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0; //igualamos i a 0 para volver a permitir la reduccion de tamaño
                }
            }
        }
        else //si "floored" es false (implicando que esamos ene el aire) se ejecuta este bloque
        {
            if (Input.GetKeyDown(KeyCode.S)) //comprueba si estamos presionando la S, mientras estamos ene el aire ene este caso
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse); //añade una fuerza negativa en el eje Y para descender mas rapido
            }
        }
    }

    public void OnCollisionEnter(Collision collision) //evento cuando se inicia una colision
    {
        if (collision.gameObject.CompareTag("Enemy")) //si colisinoamos con algo con el tag de enemigo
        {
            if (!parry)
            {
                Destroy(this.gameObject); //destruimos al jugador
                Controller_Hud.gameOver = true; //mostramos la pantalla de game over
                Parallax.gameOver = true;
            }
            else
            {
                Controller_Enemy.parried = true;                
            }
        }

        if (collision.gameObject.CompareTag("Floor")) // si colisionamos con algo ocn el tag de piso
        {
            floored = true; //seteamos floored en true para indicar que estamos sobre el piso
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {
            buffed = true;
            Controller_PU.picked = true;
            buffedtime += 5;
        }
    }

    private void OnCollisionExit(Collision collision) //evento cunado se termina una colision 
    {
        if (collision.gameObject.CompareTag("Floor")) //si dajamos de colisionar con el tag de piso
        {
            floored = false; //seteamos floored en false para indicar que estamos en el aire
        }
    }
}
