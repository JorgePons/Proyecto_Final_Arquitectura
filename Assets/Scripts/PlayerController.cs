using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Conjunto de propiedades del jugador como su velocidad y su fuerza de salto además de los inputs y el propio resultado de las acciones
    //El método de comprobación de si el objeto está en el suelo o no está en otro script al que se accede desde aquí

    public float speed;
    public float jumpForce;
    Rigidbody2D rb;

    float x;
    float y;

    Vector2 dir;

    GroundCollisionDetection collision;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<GroundCollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        dir = new Vector2(x, y);
        Walk(dir);

        if (Input.GetKeyDown(KeyCode.Space)&&collision.isGrounded)
        {
            Jump();
        }
    }

    void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x*speed, rb.velocity.y));
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }



}
