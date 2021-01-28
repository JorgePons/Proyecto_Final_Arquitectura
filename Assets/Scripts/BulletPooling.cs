using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{

    public static BulletPooling sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    //Se crea una lista pool de gameobjects bala con un tamaño int, todo público para poder asignar el gameobject y modificar el tamaño en el editor
    //Al iniciar la escena se instancia el número designado de balas y se desactivan

    public List<GameObject> bulletPool;
    public GameObject bullet;
    public int poolSize;

    private void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newBullet = (GameObject)Instantiate(bullet);
            newBullet.SetActive(false);
            bulletPool.Add(newBullet);
        }
    }

    //Esta función lee los objetos instanciados por la lista pool utilizando un bucle for y comprueba si están activos en la jerarquía
    //Dado que este script es una instancia estática y solo existe uno en toda la escena, otros scripts pueden acceder a esta función
    //Al llamarla, se inicia el bucle y se devuelve el primer objeto de la lista que se encuentre desactivado en ese momento

    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    



}
