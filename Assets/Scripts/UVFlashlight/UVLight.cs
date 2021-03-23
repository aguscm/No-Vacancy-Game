using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UVLight : MonoBehaviour
{
    public Material reveal;

    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reveal != null)
        {
            reveal.SetVector("_LightPosition", light.transform.position);
            reveal.SetVector("_LightDirection", -light.transform.forward);
            reveal.SetFloat("_LightAngle", light.spotAngle);
        }
    }
}
