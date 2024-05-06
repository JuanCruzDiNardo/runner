using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> PowerUPs;
    public GameObject instantiatePos;
    public float respawningTimer;
    public float buffTimer;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2; //establece la velocidad con la que va a acelerar el enemigo
        Controller_PU.buffVelocity = 1;
    }

    void Update()
    {
        SpawnEnemies();
        SpawBuff();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime; //cuenta el tiempo total de juego 
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f); //genera un aumento gradual de la velocidad conforme avanza el tiempo de juego
        Enemy_Rotation.rotation = Mathf.SmoothStep(1f, 30f, time / 45f);
    }

    private void SpawBuff()
    {
        buffTimer -= Time.deltaTime;

        if (buffTimer <= 0)
        {            
            Instantiate(PowerUPs[UnityEngine.Random.Range(0, PowerUPs.Count)], instantiatePos.transform);
            buffTimer = UnityEngine.Random.Range(10, 15); 
        }
    }

    private void SpawnEnemies()
    {
        respawningTimer -= Time.deltaTime; //le restamos un segundo al contador 

        if (respawningTimer <= 0) // si el contador es 0 o menos
        {
            //genera un numero random en 0 y la cantida de enemigos para determinar cual es el enemigo que genera de todos los disponibles
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform); 
            respawningTimer = UnityEngine.Random.Range(2, 6); //genera un random entre 2 y 5 para determinar el tiempo en segundos entre spaws
        }
    }
}
