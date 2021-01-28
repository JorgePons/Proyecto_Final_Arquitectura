using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDirection : MonoBehaviour
{

    //Fuerza inicial al enemigo además de un rebote más consistente al tocar el suelo
    //Fuerza extra al chocar contra los muros para evitar casos en los que pierda fuerza y se mantenga en el sitio

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(500, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(400, 200));
        }
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }

    }


}
