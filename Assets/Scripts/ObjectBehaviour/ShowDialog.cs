using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDialog : MonoBehaviour
{
    public GameObject DialogObject;
    public TextMeshProUGUI mText;
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
            appearDialog(textToShow[positionTextArray]);
            positionTextArray++;
            if (positionTextArray >= textToShow.Length) {
                positionTextArray = 0;
            };
        }  
    }

    public void appearDialog(string text) {
        mText.text = text;
        DialogObject.SetActive(true);
        exitDialog();
    }

    public void exitDialog() {
        StopCoroutine(exitDialogCoroutine());
        StartCoroutine(exitDialogCoroutine());
    }

        IEnumerator exitDialogCoroutine()
    {
        yield return new WaitForSeconds(secondsToFade);
        mText.text = "";
        DialogObject.SetActive(false);
    }
}
