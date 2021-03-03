using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackboardPuzzlePiece: MonoBehaviour
{   
    public BlackboardPuzzle puzzle;
    private string[] suitcaseValues = {"-", "Orange", "Blue", "Green", "Purple", "Red"};//correct is: {"Red", "Green", "Orange", "Blue", "Purple"};
    private string[] drinkValues = {"-", "Rum", "Beer", "Water", "Wine", "Milk"};//correct is: {"Water", "Wine", "Milk", "Rum", "Beer"};
    private string[] values;
    public bool isDrink;
    public int index = 0;
    public string selectedValue;

    
    void Start()
    {
       //Starts the 'values' array depending of its nature (suitcase or drink)
        if (isDrink) {
            values = drinkValues;
        }else {
            values = suitcaseValues;
        }
        //Sets the selected value in "-" and paint it on the blackboard
        selectedValue = values[0];
        paintInBlackboard(selectedValue);
    }

    //Updates the text of the blackboard by moving to the next index of the array
    public void onClick() {          

            if (index < values.Length -1) {
                index++;
                selectedValue = values[index];
                paintInBlackboard(selectedValue);
            }

            if (index >= values.Length -1) {
                index = -1;
            }

            //Checks if it is the correct answer
            if (puzzle.checkAnswer()) {
                puzzle.win();
            }


    }

    //The selectedValue getter
    public string getSelectedValue() {
        return selectedValue;
    }

    public void paintInBlackboard(string text) {
        this.GetComponent<TextMeshPro>().SetText(text);
    }


}
