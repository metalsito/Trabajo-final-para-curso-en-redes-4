using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento : MonoBehaviour
{
    public float tiempoDamp = 0.2f;
    public float tiempoZoom = 0.2f;
    Vector3 velMovimiento;
    private Camera camara;
    private float velZoom;
    private void Start()
    {
        camara = GetComponentInChildren<Camera>();    
    }

    private void FixedUpdate()
    {
        Vector3 posObjt = Mover();
        Zoom(posObjt);
    }

    private void Zoom(Vector3 posObjt)
    {
        float tamanioObj = BuscarTamanioObjetivo(posObjt);
        camara.orthographicSize = Mathf.SmoothDamp(camara.orthographicSize, tamanioObj,
            ref velZoom, tiempoZoom);
    }

    public float minTamanioCamara = 5f;
    public float extraTamanioCamara = 2f;
    public float dist2Tamanio = 1f;
    private float BuscarTamanioObjetivo(Vector3 posObjt)
    {
        float distMax = DistanciaMaxima(posObjt);
        float zoom = distMax * dist2Tamanio + extraTamanioCamara;
        return Mathf.Max(zoom, minTamanioCamara);
    }

    private float DistanciaMaxima(Vector3 posObj)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        float max = -1f;
        for (int p = 0; p < objs.Length; p++)
        {
            float dist = (posObj - objs[p].transform.position).magnitude;
            if(dist > max)
            {
                max = dist;
            }
        }
        return max;
    }

    Vector3 Mover()
    {
        Vector3 objetivo = BuscarPosicionDeseada();
        transform.position = Vector3.SmoothDamp(transform.position,
            objetivo, ref velMovimiento, tiempoDamp);
        return objetivo;
    }

    Vector3 BuscarPosicionDeseada()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        Vector3 promedio = Vector3.zero;
        for(int p = 0; p < objs.Length; ++p)
        {
            promedio += objs[p].transform.position;
        }
        return promedio;
    }
}
