using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialReveal : MonoBehaviour
{
    public UVLight uvLight;

    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void Reveal()
    {   
        GetComponent<Renderer>().enabled = true;
        uvLight.reveal = material;
    }

    public void Unreveal()
    {
        GetComponent<Renderer>().enabled = false;
        uvLight.reveal = null;
    }
}
