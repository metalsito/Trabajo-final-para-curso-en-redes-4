using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaEnemigoDaño : NetworkBehaviour
{
    public GameObject explosion;

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
      if (other.tag == "Player")
      {
                //Vidas player = FindObjectOfType<Vidas>();
                Vidas Player = other.GetComponent<Vidas>();
                Player.vida -= 25;
                Instantiate(explosion, transform);
                NetworkServer.Destroy(gameObject);
      }

      if (other.tag != "Player" && other.tag != "Enemy")
      {
                Instantiate(explosion, transform);
                NetworkServer.Destroy(gameObject);
      }
        
    }
}
