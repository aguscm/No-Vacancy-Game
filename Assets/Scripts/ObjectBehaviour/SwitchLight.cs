using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    public Light[] lights; //Array of lights

    // Start is called before the first frame update
    void Start()
    {
        foreach (Light light in lights) {
            light.GetComponent<Light>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Switch on & off the ligths in the array
    public void Switch() {
        foreach (Light light in lights) {
            light.enabled = !light.enabled;
        }
   }
    
}
