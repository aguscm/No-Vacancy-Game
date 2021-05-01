using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : BlackboardPiece
{
    public enum PossibleValues
    {
        Null,
        Orange,
        Blue,
        Green,
        Purple,
        Red
    }

    public PossibleValues correctValue;

    public PossibleValues currentValue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void onClick()
    {
        getNextValue(); //Gets the next value of the enum (if there isn't on the blackboard yet)
        base.paintInBlackboard(ToString(currentValue)); //Prints it
        blackboard.checkPuzzle(); //Checks the blacboard puzzle 
    }

    public static string ToString(PossibleValues enumPos)
    {
        switch ((int) enumPos)
        {
            case 0:
                return "-";
                break;
            case 1:
                return "Orange";
                break;
            case 2:
                return "Blue";
                break;
            case 3:
                return "Green";
                break;
            case 4:
                return "Purple";
                break;
            case 5:
                return "Red";
                break;
        }
        return "-";
    }

    public void getNextValue() {

        //If the next value exceeds the limit of the length, the value is 0 ("-")
        if ((int)currentValue+1 >= Enum.GetNames(typeof (PossibleValues)).Length) {
            currentValue = (PossibleValues)(0);
        //If not, the next value will be the next in the Enum
        }else {
            currentValue =  (PossibleValues)((int) currentValue + 1);

            //If the new value is already in the blackboard in some of the other values, it will get the next number
            for (int i = 0; i < blackboard.colorPieces.Length; i++) {
                //If the iteration is over the current game object, skips this iteration
                if (this.gameObject == blackboard.colorPieces[i].gameObject) {
                    continue;
                }
                //If the value is equal to another value in the blackboard, it searchs for the next value (repeats the function)
                if (currentValue == blackboard.colorPieces[i].currentValue) {
                    getNextValue();
                    break;
                }
            }
        }
    }
}
