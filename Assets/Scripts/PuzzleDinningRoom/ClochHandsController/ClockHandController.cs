using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandController : MonoBehaviour
{
    private Transform clockHand;
    private float currentRotation;
    private int time;
    public ClockController clock; //The parent object which will check the correct time
    // Start is called before the first frame update
    void Start()
    {
        clockHand = GetComponent<Transform>();
        currentRotation = clockHand.localRotation.eulerAngles.z;
        getTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotate() {
        currentRotation += 30;
        clockHand.localRotation = Quaternion.Euler(0, 0, currentRotation);
        getTime();

        //Checks the time
        clock.checkCorrectTime();
    }
    //Gets the time in an 0-11 scale
    public int getTime() {
        time = (int)currentRotation%360 / 30;
        return time;
    }
}
