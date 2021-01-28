using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{

    //Al colisionar con el jugador, este script le resta vida y puntos además de activar sus frames de invencibilidad si no están activados ya
    //En caso de que la vida del jugador llegue a 0 tras la colisión, llama a la función de terminar la partida con derrota

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats.isInvincible == false)
            {
                playerStats.hp--;
                ScoreManager.score -= 20;
                if (playerStats.hp <= 0)
                {
                    EndGameScript.sharedInstance.Defeat();
                }
                playerStats.StartInvincibility();
            }
        }
    }
}
