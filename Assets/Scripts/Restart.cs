using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R)) //checkeamos que se presione la tecla R
        {
            Parallax.gameOver = false;
            Time.timeScale = 1; //reanudamos el tiempo del juego
            SceneManager.LoadScene(0); //cargamos la escena inicial 
        }
    }
}
 