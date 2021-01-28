using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionDetection : MonoBehaviour
{

    //Uso de un OverlapCircle y de las LayerMasks para detectar qué objeto es el suelo
    //Contiene variables de radio y offset que junto a su representación en el editor con gizmos permiten su edición en Unity

    public bool isGrounded;
    public LayerMask groundLayer;
    public float radius;
    public Vector2 bottomOffset;
    Color collisionColor = Color.red;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, radius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, radius);
    }

}
