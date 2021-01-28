using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //Stat de puntos de vida del jugador y estado de invencibilidad post-daño
    //Cuando un enemigo choca con el jugador y le hace daño activa el bool de invencibilidad y la animación de parpadeo
    //Una vez dicha animación termine se llama a StopInvencibility para que el jugador vuelva por completo a su estado normal
    //Se incluye también la colisión con los objetos curativos aquí, recupera vida y accede al ScoreManager para aumentar puntos

    public float hp;
    public bool isInvincible = false;

    Animator anim;

    private void Start()
    {
        hp = 10;
        anim = GetComponent<Animator>();
    }

    public void StartInvincibility()
    {
        anim.SetTrigger("Hit");
        isInvincible = true;
    }

    public void StopInvincibility()
    {
        isInvincible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Health")
        {
            hp += 2;
            ScoreManager.score += 30;
            Destroy(collision.gameObject);
        }
    }


}
