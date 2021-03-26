using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UVLight : MonoBehaviour
{
    public Material reveal;

    public MaterialReveal objectWithMaterial;

    private Light light;

    public KeyCode switchLightKey;

    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchLightKey))
        {
            Switch();
        }

        if (reveal != null && on)
        {
            reveal.SetVector("_LightPosition", light.transform.position);
            reveal.SetVector("_LightDirection", -light.transform.forward);
            reveal.SetFloat("_LightAngle", light.spotAngle);
        }
    }

    void Switch()
    {
        on = !on;
        if (on)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
            if (objectWithMaterial)
            {
                objectWithMaterial.Unreveal();
            }
        }
    }
}
