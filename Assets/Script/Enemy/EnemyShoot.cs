using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyShoot :NetworkBehaviour
{

    public Transform radiusDetector;
    public GameObject bullet, shootPoint;
    public LayerMask player;
    public float radius, timer;
    public bool lookPlayer;


    private void Start()
    {

    }

    void Update()
    {
        LookPlayerTrue();
        LookToPlayer();
        Shoot();
    }

    void LookPlayerTrue()
    {
        lookPlayer = Physics.CheckSphere(radiusDetector.position, radius, player);
    }

    void LookToPlayer()
    {
        if (lookPlayer == true)
        {
            Vidas player = FindObjectOfType<Vidas>();
            transform.LookAt(player.transform);
        }
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (lookPlayer == true && timer > 2)
        {
            Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(radiusDetector.position, radius);
    }
}
