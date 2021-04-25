using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeNumber : MonoBehaviour
{
    public SafeControllerPuzzle safeControllerPuzzle;
    public int value = 0;
    public bool ischeckButton = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getValue() {
        return value;
    }

    public void onClick() {
        if (!ischeckButton) {
            advanceNumber();
        }else {
           safeControllerPuzzle.checkPuzzle();
        }
        
        
    }

    public void advanceNumber() {
        if (value+1 == 10) {
            value = 0;
        }else {
            value++;
        }
        
        this.GetComponent<TextMeshPro>().SetText(value.ToString());
    }


}
