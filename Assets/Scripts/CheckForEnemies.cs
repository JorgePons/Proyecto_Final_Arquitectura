using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEnemies : MonoBehaviour
{

    public static CheckForEnemies sharedInstance;

    public Transform enemyParent;

    private void Awake()
    {
        sharedInstance = this;
    }

    //Este bucle for lee los objetos hijo del gameobject vacío que contiene a los enemigos
    //Si en el ciclo detecta algún objeto activado, se rompe. Pero si no detecta ninguno se inicia la secuencia de victoria

    public void EnemyCheckLoop()
    {
        for (int i = 0; i < enemyParent.childCount; i++)
        {
            if (enemyParent.GetChild(i).gameObject.activeInHierarchy == false)
            {
                if (i >= enemyParent.childCount-1)
                {
                    EndGameScript.sharedInstance.Victory();
                }
            }
            else
            {
                i = 0;
                break;
            }
        }
    }








}
