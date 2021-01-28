using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

    //Input del botón para disparar. Cuando este se pulsa se llama a la función que mediante object pooling devuelve la primera bala disponible
    //Al devolver esa bala, se posiciona sobre el lugar de disparo y se activa para que siga su camino

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = BulletPooling.sharedInstance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
    }

}
