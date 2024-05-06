using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    public Text bufftimetext;
    private float distance = 0;

    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver) //checkeamos el estado de la variable, que se actualiza desde el script del jugador
        {
            Time.timeScale = 0; //detenemos el juego 
            gameOverText.text = "Game Over \n Total Distance: " + Mathf.Round(distance).ToString(); //establecemos el texto y le agregamos la distancia total
            gameOverText.gameObject.SetActive(true); //hacemos el texto visible
        }
        else
        {
            distance = distance + Time.deltaTime; //sumamos el conteo de tiempo a la variable de distancia 
            distanceText.text = Mathf.Round(distance).ToString(); //actualizamos el valor del texto con el valor contado
            bufftimetext.text = Mathf.Round(Controller_Player.buffedtime).ToString();
        }
    }
}
