using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{

    //Generación de una posición aleatoria entre 2 esquinas límite puestas en la escena
    //Corrutina con un tiempo de espera para generar un objeto curativo cada X tiempo llamando a la clase ProcHealth

    public float timeRespawn;

    public float randomX;
    public float randomY;

    public Transform topLeft;
    public Transform bottomRight;

    private void Start()
    {
        new WaitForSeconds(timeRespawn);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        randomX = Random.Range(topLeft.position.x, bottomRight.position.x);
        randomY = Random.Range(topLeft.position.y, bottomRight.position.y);
        GameObject healthPickup = ProcHealth.Clone(new Vector3(randomX,randomY,-1));
        healthPickup.transform.SetParent(gameObject.transform);

        yield return new WaitForSeconds(timeRespawn);

        StartCoroutine(Respawn());
    }
}
