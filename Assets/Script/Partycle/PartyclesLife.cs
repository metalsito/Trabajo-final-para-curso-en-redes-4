using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PartyclesLife : NetworkBehaviour
{
    public float timer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            NetworkServer.Destroy(gameObject);
        }
	}
}
