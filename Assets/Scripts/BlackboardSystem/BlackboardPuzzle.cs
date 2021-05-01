using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public string[] values;

    public string[] valuesDrink;

    public string[] valuesSuitcase;

    private string[] correctAnswerDrink = { "Water", "Wine", "Milk", "Rum", "Beer" };

    private string[] correctAnswerSuitcase = { "Red", "Green", "Orange", "Blue", "Purple" };

    public GameObject newspapers;

    // Start is called before the first frame update
    void Start()
    {
        values = new string[10];
        valuesDrink = new string[5];
        valuesSuitcase = new string[5];
        updateValues();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Checks in the input values if all have the correct answer
    public bool checkAnswer()
    {
        updateValues();
        for (var i = 0; i < valuesDrink.Length; i++)
        {
            if (this.valuesDrink[i] == correctAnswerDrink[i])
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        for (var i = 0; i < valuesSuitcase.Length; i++)
        {
            if (this.valuesSuitcase[i] == correctAnswerSuitcase[i])
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    private void updateValues()
    {
        this.valuesDrink[0] = SmithDrink.getSelectedValue();
        this.valuesDrink[1] = OdonellDrink.getSelectedValue();
        this.valuesDrink[2] = MauDrink.getSelectedValue();
        this.valuesDrink[3] = NairaDrink.getSelectedValue();
        this.valuesDrink[4] = BigottDrink.getSelectedValue();
        this.valuesSuitcase[0] = SmithSuitcase.getSelectedValue();
        this.valuesSuitcase[1] = OdonellSuitcase.getSelectedValue();
        this.valuesSuitcase[2] = MauSuitcase.getSelectedValue();
        this.valuesSuitcase[3] = NairaSuitcase.getSelectedValue();
        this.valuesSuitcase[4] = BigottSuitcase.getSelectedValue();
    }

    public void win()
    {
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

        newspapers.SetActive(true);
    }
}
