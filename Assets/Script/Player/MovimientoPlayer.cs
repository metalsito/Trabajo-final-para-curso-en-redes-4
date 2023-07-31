using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovimientoPlayer : NetworkBehaviour
{
    string axisMovimiento = "Vertical1";
    string axisRotacion = "Horizontal1";
    float movimiento;
    float rotacion;
    public float velRotacion = 45f;
    public float velMovimiento = 5f;
    Rigidbody rb;
       
	// Use this for initialization
	void Start ()
    {
       rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer) return;
        movimiento = Input.GetAxis(axisMovimiento);
        rotacion = Input.GetAxis(axisRotacion);
	}

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        Mover();
        Rotar();
    }

    void Mover()
    {
        Vector3 mov = transform.forward * movimiento * Time.deltaTime * velMovimiento;
        rb.MovePosition(rb.position + mov);
    }

    void Rotar()
    {
        float rot = rotacion * Time.deltaTime * velRotacion;
        Quaternion quat = Quaternion.Euler(0, rot, 0);
        rb.MoveRotation(rb.rotation * quat);
    }
}
