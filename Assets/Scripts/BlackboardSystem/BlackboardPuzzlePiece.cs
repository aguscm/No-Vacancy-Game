using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlackboardPuzzlePiece : MonoBehaviour
{
    public BlackboardPuzzle puzzle;

    private string[]
        suitcaseValues = { "Orange", "Blue", "Green", "Purple", "Red" }; //correct is: {"Red", "Green", "Orange", "Blue", "Purple"};

    private string[] drinkValues = { "Rum", "Beer", "Water", "Wine", "Milk" }; //correct is: {"Water", "Wine", "Milk", "Rum", "Beer"};

    public string[] values;

    public bool isDrink;

    public int index = 0;

    public string selectedValue;

    public string correctValue;

    void Start()
    {
        //Starts the 'values' array depending of its nature (suitcase or drink)
        //Sets the selected value in "-" and paint it on the blackboard
        getPossibleValuesToShow();
        selectedValue = values[0];
        paintInBlackboard (selectedValue);
    }

    //Updates the text of the blackboard by moving to the next index of the array
    public void onClick()
    {
        getPossibleValuesToShow();
        if (index < values.Length - 1)
        {
            index++;
            selectedValue = values[index];
            paintInBlackboard (selectedValue);
        }

        if (index >= values.Length - 1)
        {
            index = -1;
        }

        //Checks if it is the correct answer
        if (puzzle.checkAnswer())
        {
            puzzle.win();
        }
    }

    //The selectedValue getter
    public string getSelectedValue()
    {
        return selectedValue;
    }

    public void paintInBlackboard(string text)
    {
        this.GetComponent<TextMeshPro>().SetText(text);
    }

    // public string[] getPossibleValuesToShow() {
    //    // puzzle.updateValues();
    //    List<string> possibleValues = new List<string>();
    //     if (isDrink) {
    //         for (int i = 0; i < 4; i++) {
    //             if (puzzle.values[i] != "-") {
    //             }
    //         }
    //     }
    // }
    public void getPossibleValuesToShow()
    {
        var possibleValues = new List<string>();
        possibleValues.Add("-");
        if (isDrink)
        {
            for (int i = 0; i < drinkValues.Length; i++)
            {
                var isAlreadyPrinted = false;
                for (int j = 0; j < puzzle.valuesDrink.Length; j++)
                {
                    if (drinkValues[j] == puzzle.valuesDrink[j])
                    {
                        isAlreadyPrinted = true;
                        break;
                    }
                }
                if (!isAlreadyPrinted)
                {
                    possibleValues.Add(drinkValues[i]);
                }
            }
            values = possibleValues.ToArray();
        }
        else
        {
            values = suitcaseValues;
        }
    }
}
