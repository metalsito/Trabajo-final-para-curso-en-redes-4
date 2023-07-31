using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VidaEnemigo : NetworkBehaviour
{
    public GameObject explosion;
    public float vidaMax = 100f;
    [SyncVar]
    public float vida;
   // [SyncVar]
   // bool estaMuerto = false;



    // Use this for initialization
    void Start()
    {
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        Morir();
    }

    [ServerCallback]
    private void Morir()
    {
        if (vida <= 0)
        {
            Instantiate(explosion, transform);
            NetworkServer.Destroy(gameObject);
        }
    }
}
