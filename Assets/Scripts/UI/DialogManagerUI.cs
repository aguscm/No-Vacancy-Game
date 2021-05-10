using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManagerUI : MonoBehaviour
{
    public GameObject canvasUI;

    public TextMeshProUGUI mText;

    private float realTime = 0;

    public float timeToFade = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;
        if (realTime > timeToFade) {
            exitDialog();
        }
    }

    public void activateCanvas()
    {
        canvasUI.SetActive(true);
    }

    public void hideCanvas()
    {
        canvasUI.SetActive(false);
    }

    public void showText(string text, float secondsToFade)
    {
        timeToFade = secondsToFade;
        realTime = 0;
        activateCanvas();
        mText.text = text;
    }

    private void exitDialog() {
        mText.text = "";
        canvasUI.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
