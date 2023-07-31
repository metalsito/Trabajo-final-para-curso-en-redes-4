using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Disparar : NetworkBehaviour
{
    public string axisDisparo = "Fire1";
    public float velDisparo = 5f;
    private Rigidbody rb;
    public Rigidbody prefabBala;
    public Transform origenBala;
    public float timer;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }
    [ClientCallback]
    private void Update()
    {
        if (Input.GetButtonDown(axisDisparo))
        {
            if (!isLocalPlayer)
            {
                return;
            }
            Disparo();
        }
        timer += Time.deltaTime;
    }

    void Disparo()
    {
        if (timer >= 1)
        {
            CmdFire(rb.velocity, origenBala.forward, origenBala.position, origenBala.rotation);
            timer = 0;
        }
    }
    [Command]
    private void CmdFire(Vector3 velTanque, Vector3 dir, Vector3 pos, Quaternion rot)
    {
        Rigidbody rbBala = Instantiate<Rigidbody>(prefabBala, pos, rot);
        rbBala.velocity = velTanque + dir * velDisparo;
        NetworkServer.Spawn(rbBala.gameObject);
    }
}
