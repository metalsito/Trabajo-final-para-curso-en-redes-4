using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaMove : NetworkBehaviour
{
    public float speed = 15, timer;
	
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        BulletMovement();
	}

    private void BulletMovement()
    {
        timer += Time.deltaTime;
        transform.Translate(0, 0, speed * Time.deltaTime);
        if(timer >= 3)
        {
            Destroy(gameObject);
        }
    }
}
