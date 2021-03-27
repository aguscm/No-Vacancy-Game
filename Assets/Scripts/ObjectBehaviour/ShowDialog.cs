using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDialog : MonoBehaviour
{
    public GameObject DialogObject;
    public TextMeshProUGUI mText;
    public int secondsToFade = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void appearDialog(string text) {
        mText.text = text;
        DialogObject.SetActive(true);
        exitDialog();
    }

    public void exitDialog() {
        StartCoroutine(exitCoroutine());
    }

        IEnumerator exitCoroutine()
    {
        yield return new WaitForSeconds(secondsToFade);
        mText.text = "";
        DialogObject.SetActive(false);
    }
}
