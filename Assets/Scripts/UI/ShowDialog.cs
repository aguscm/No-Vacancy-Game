using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDialog : MonoBehaviour
{
    public DialogManagerUI dialogManager;
    public string[] textToShow;
    private int positionTextArray = 0;
    public bool showDialogOnClick;
    public int secondsToFade = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Shows dialog only when the user clicks on the object
    public void appearDialogOnClick() {
        if (showDialogOnClick) {
            dialogManager.gameObject.SetActive(true);
            dialogManager.showText(textToShow[positionTextArray],secondsToFade);
            positionTextArray++;
            if (positionTextArray >= textToShow.Length) {
                positionTextArray = 0;
            };
        }  
    }

    public void appearDialog(string text) {
        dialogManager.gameObject.SetActive(true);
        dialogManager.showText(text,secondsToFade);
    }
}
