using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomPuzzleController : MonoBehaviour
{
    public Sink[] sinks;
    public bool sinkPuzzleResolved = false;
    public int closedSinks = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Control()
    {
        

        //Sinks puzzle
        closedSinks = 0;
        foreach (Sink sink in sinks)
        {
            if (sink.open == false) {
                closedSinks++;
            }
        }
        if (closedSinks == sinks.Length) {
            sinkPuzzleResolved = true;
        }else {
            sinkPuzzleResolved = false;
        }
    }
}
