using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentViewerUI : MonoBehaviour
{
    public CanvasDocumentViewerUI canvas; //The canvas to activate
    public Image[] imagesToShow; //The list of images to show in canvas; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EnterViewer()
    {
        canvas.gameObject.SetActive(true);
        canvas.ShowImages(imagesToShow);
    }
}
