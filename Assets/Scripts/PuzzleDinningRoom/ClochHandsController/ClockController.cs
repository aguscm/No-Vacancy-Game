using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public int correctHour = 8; //Scale from 0 to 11. Ex. 0 is 12h
    public int correctMinute = 9; //Scale from 0 to 11. Ex. 9 is 45minutes

    public ClockHandController hour;
    public ClockHandController minute;

    public GameObject mannequinScene;

    public Light[] lightsOff;

    private MakeSound sound;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<MakeSound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCorrectTime() {
        if (hour.getTime() == correctHour && minute.getTime() == correctMinute) {
            //Makes the hands clock unselectable
            hour.gameObject.tag = "Untagged";
            minute.gameObject.tag = "Untagged";
            //Activates the mannequin scene
            activateMannequinScene();
            switchOffLights(); //Switch off the lights of the kitchen
            sound.Play();
        }
    }

    public void activateMannequinScene() {
        mannequinScene.SetActive(true);
    }

    private void switchOffLights() {
         foreach (Light light in lightsOff) {
            light.enabled = !light.enabled;
        }
    }
}
