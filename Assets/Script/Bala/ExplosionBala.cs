using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ExplosionBala : NetworkBehaviour
{
    /*public float vidaMax = 5f, radio = 5f, fuerza = 1000f, danioMax = 3f;
    private int mascaraPlayers;
	// Use this for initialization
	void Start ()
    {
        GameObject.Destroy(gameObject, vidaMax);
        GetComponent<Collider>().enabled = false;
        StartCoroutine(PrenderCollision());
        mascaraPlayers = LayerMask.GetMask("Players");
        // | este palito es un o binario.
	}
	
    IEnumerator PrenderCollision()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Collider>().enabled = true;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        NetworkServer.Destroy(gameObject);
    }

    void FuerzaExplosion()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radio, mascaraPlayers);
        for (int c = 0; c < cols.Length; c++)
        {
            Rigidbody rb = cols[c].GetComponent<Rigidbody>();
            if (rb != null && rb.GetComponent<NetworkIdentity>().hasAuthority)
                rb.AddExplosionForce(fuerza, transform.position, radio);
            Vidas vida = cols[c].GetComponent<Vidas>();
            if(!vida)
            {
                continue;
            }
            Vector3 explosion2Tanque = transform.position;
            float d = explosion2Tanque.magnitude;
            float danioRel = (radio - d) / radio;
            danioRel = Mathf.Clamp(danioRel, 0f, 1f);
            float daño = danioRel * danioMax;
            vida.RecibirDanio(daño);
            
        }
    }
    public ParticleSystem explosion;
    private void OnDestroy()
    {
        Explotar();
        ParticleSystem.MainModule modulo = explosion.main;
        GameObject.Destroy(explosion.gameObject, modulo.duration);
        base.OnNetworkDestroy();
    }

    void Explotar()
    {
        explosion.transform.parent = null;
        explosion.Play();
        FuerzaExplosion();
    }*/
}
