using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPoolItem
{
    public GameObject enemy;
    public int poolSize;
}

public class EnemyPooling : MonoBehaviour
{

    public static EnemyPooling sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public List<GameObject> enemyPool;
    public List<EnemyPoolItem> itemsToPool;

    //La lista itemsToPool contiene varias clases EnemyPoolItem, las cuales tienen dentro variables públicas del gameobject del tipo de enemigo y la cantidad
    //En el método Start se para por la cantidad de clases EnemyPoolItem dentro de la lista itemsToPool para obtener el total de gameobjects enemigos de cada tipo
    //Esta cantidad total de gameobjects enemigos se almacenan dentro de la nueva lista llamada enemyPool

    private void Start()
    {
        enemyPool = new List<GameObject>();
        foreach (EnemyPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject newEnemy = (GameObject)Instantiate(item.enemy);
                newEnemy.transform.parent = transform;
                newEnemy.SetActive(false);
                enemyPool.Add(newEnemy);
            }
        }
    }

    //La función GetEnemy recibe un valor string que corresponde al tag del objeto que se quiere recibir
    //El bucle for lee los enemigos que se crearon dentro de enemyPool y devuelve el primer objeto que esté desactivado cuyo tag corresponda al que se pide

    public GameObject GetEnemy(string tag)
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy && enemyPool[i].tag == tag)
            {
                return enemyPool[i];
            }
        }

        foreach (EnemyPoolItem item in itemsToPool)
        {
            if (item.enemy.tag == tag)
            {
                return item.enemy;
            }
        }
        return null;
    }
}
