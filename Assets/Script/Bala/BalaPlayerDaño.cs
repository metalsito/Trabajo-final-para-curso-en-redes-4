using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaPlayerDaño : NetworkBehaviour
{
    public GameObject explosion;

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //VidaEnemigo enemy = FindObjectOfType<VidaEnemigo>();
            VidaEnemigo enemy = other.GetComponent<VidaEnemigo>();
            enemy.vida -= 50;
            Instantiate(explosion, transform);
            NetworkServer.Destroy(gameObject);

        }

        if (other.tag != "Enemy" && other.tag != "Player")
        {
            Instantiate(explosion, transform);
            NetworkServer.Destroy(gameObject);
        }
    }

}
