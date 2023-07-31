using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColorPlayer : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        CambiarColor(Color.black);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        CambiarColor(Color.blue);
    }

    void CambiarColor(Color color)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            foreach (Material material in r.materials)
            {
                material.color = color;
            }

        }
    }
            
            
    
}
