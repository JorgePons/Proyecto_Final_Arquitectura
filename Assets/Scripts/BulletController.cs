using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    //Movimiento de la bala hacia arriba
    //En caso de que el disparo falle y salga de la pantalla, se desactiva el objeto y se restan puntos al jugador

    Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
        if (transform.position.y >= 6)
        {
            ScoreManager.score -= 5;
            gameObject.SetActive(false);
        }
    }

}
