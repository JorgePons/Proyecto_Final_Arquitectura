using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideBallScript : MonoBehaviour
{

    //Este script se llama cuando un enemigo colisiona con una bala y sirve para seguir el proceso de división de enemigos hasta su final desactivación
    //Primero se suman puntos y se desactiva la bala por haber conseguido derrotar a un enemigo
    //A continuación se cogen 2 enemigos del mismo tipo de la pool de enemigos (El tipo depende de el estado actual de la división del enemigo, ver EnemyPooling)
    //A cada uno se le asigna la posición, se activa y se le da una fuerza inicial opuesta para salir en 2 direcciones
    //Finalmente se desactiva este enemigo derrotado y se llama a la función del bucle for para comprobar el estado de los enemigos activados


    public string nextBallType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            ScoreManager.score += 40;
            collision.gameObject.SetActive(false);
            GameObject nextBall01 = EnemyPooling.sharedInstance.GetEnemy(nextBallType);
            if (nextBall01 != null)
            {
                nextBall01.transform.position = transform.position;
                nextBall01.SetActive(true);
                nextBall01.GetComponent<Rigidbody2D>().velocity = (new Vector2(10, 3));
            }
            GameObject nextBall02 = EnemyPooling.sharedInstance.GetEnemy(nextBallType);
            if (nextBall02 != null)
            {             
                nextBall02.transform.position = transform.position;
                nextBall02.SetActive(true);
                nextBall01.GetComponent<Rigidbody2D>().velocity = (new Vector2(-20, 3));
            }
            gameObject.SetActive(false);
            CheckForEnemies.sharedInstance.EnemyCheckLoop();
        }
    }

}
