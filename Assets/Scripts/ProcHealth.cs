using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcHealth: Object
{

    //Patrón Prototype
    //Este script es una clase que no deriva de Monobehaviour puesto que no se va a asignar a ningún objeto de la escena
    //Cualquier script puede acceder al contenido de esta clase
    //En esta función se crea un objeto completamente nuevo desde al que se le asignan todos los componentes necesarios y sus características
    //A partir de ahí se creará un clon con estas misma características cuando se llame a la función

    public static GameObject Clone(Vector3 pos)
    {

        Texture2D tex = new Texture2D(64, 64);

        GameObject healthPickup = new GameObject();
        healthPickup.AddComponent<SpriteRenderer>();
        healthPickup.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        healthPickup.GetComponent<SpriteRenderer>().color = Color.green;
        healthPickup.AddComponent<Rigidbody2D>();
        healthPickup.GetComponent<Rigidbody2D>().sharedMaterial = new PhysicsMaterial2D();
        healthPickup.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0.2f;
        healthPickup.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = 1;
        healthPickup.AddComponent<BoxCollider2D>();
        healthPickup.name = "Health(Clone)";
        healthPickup.tag = "Health";
        healthPickup.layer = 11;
        healthPickup.gameObject.SetActive(true);
        healthPickup.transform.position = pos;
        healthPickup.transform.localScale = new Vector3(1f, 1f, 1f);

        return healthPickup;
    }

}
