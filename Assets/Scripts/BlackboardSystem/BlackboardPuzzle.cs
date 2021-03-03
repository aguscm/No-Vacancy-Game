using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackboardPuzzle : MonoBehaviour
{
    public BlackboardPuzzlePiece SmithDrink;
    public BlackboardPuzzlePiece SmithSuitcase;
    public BlackboardPuzzlePiece OdonellDrink;
    public BlackboardPuzzlePiece OdonellSuitcase;
    public BlackboardPuzzlePiece MauDrink;
    public BlackboardPuzzlePiece MauSuitcase;
    public BlackboardPuzzlePiece NairaDrink;
    public BlackboardPuzzlePiece NairaSuitcase;
    public BlackboardPuzzlePiece BigottDrink;
    public BlackboardPuzzlePiece BigottSuitcase;
    public string [] values;
    private string[] correctAnswer = {"Water", "Wine", "Milk", "Rum", "Beer", "Red", "Green", "Orange", "Blue", "Purple"};


    // Start is called before the first frame update
    void Start()
    {
        values = new string[10];
        updateValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checks in the input values if all have the correct answer
    public bool checkAnswer() {
        updateValues();
        for (var i = 0; i < values.Length; i++) {
            if (this.values[i] == correctAnswer[i]) {
                continue;
            }else {
                return false;
            }
        }
        return true;
    }

    private void updateValues() {
        this.values[0] = SmithDrink.getSelectedValue();
        this.values[1] = OdonellDrink.getSelectedValue();
        this.values[2] = MauDrink.getSelectedValue();
        this.values[3] = NairaDrink.getSelectedValue();
        this.values[4] = BigottDrink.getSelectedValue();
        this.values[5] = SmithSuitcase.getSelectedValue();
        this.values[6] = OdonellSuitcase.getSelectedValue();
        this.values[7] = MauSuitcase.getSelectedValue();
        this.values[8] = NairaSuitcase.getSelectedValue();
        this.values[9] = BigottSuitcase.getSelectedValue();
    }

    public void win() {
        SmithDrink.gameObject.transform.tag = "Untagged";
        OdonellDrink.gameObject.transform.tag = "Untagged";
        MauDrink.gameObject.transform.tag = "Untagged";
        NairaDrink.gameObject.transform.tag = "Untagged";
        BigottDrink.gameObject.transform.tag = "Untagged";
        SmithSuitcase.gameObject.transform.tag = "Untagged";
        OdonellSuitcase.gameObject.transform.tag = "Untagged";
        MauSuitcase.gameObject.transform.tag = "Untagged";
        NairaSuitcase.gameObject.transform.tag = "Untagged";
        BigottSuitcase.gameObject.transform.tag = "Untagged";
    }
}
