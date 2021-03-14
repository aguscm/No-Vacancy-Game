using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class CanvasDocumentViewerUI : MonoBehaviour
{
    private Image[] imagesToShow;

    public GameObject objBackground;
    private RectTransform rect;

    public int imgCounter;

    public int nCurrentImage = 0;

    public KeyCode action;
    public KeyCode escape;

    public FirstPersonController player;
    //Controlling mouse wheel
    private float scale = 1;
    public float minScale = 0.5f;
    public float maxScale = 7f;
    private float movementFactor = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
      rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Zoom in and out with mouse wheel
        if(scale < minScale) {
             scale = minScale;
         }else if (scale > maxScale) {
             scale = maxScale;
         }else {
             scale = scale + Input.mouseScrollDelta.y*0.5f;
         }
        
       rect.localScale = new Vector2(scale, scale);
        //Moves to the next image of the array of ends this view if the image was the last one
        if (Input.GetKeyDown(action))
        {
            nCurrentImage++;

            if (nCurrentImage < imgCounter)
            {
                imagesToShow[nCurrentImage - 1].GetComponent<Image>().enabled =
                    false;
                imagesToShow[nCurrentImage].GetComponent<Image>().enabled =
                    true;

                //scale = 1;
            }
            else
            {
                Resume();
            }
        }

        //Resumes the game if escape key is pressed
        if (Input.GetKeyDown(escape)) {
            Resume();
        }
    }

    public void ShowImages(Image[] imagesToShow)
    {
        //Block the movement of the player
        Cursor.visible = true;
        Screen.lockCursor = false;
        player.enabled = false;


        //Shows the background color of the canvas
        objBackground.SetActive(true);

        //Wipes the screen of all the previous images
        wipeScreen();

        //Shows the first image of the array
        this.imagesToShow = imagesToShow;
        imgCounter = imagesToShow.Length;
        imagesToShow[nCurrentImage].GetComponent<Image>().enabled = true;
        //Time.timeScale = 0;
    }

    public void wipeScreen()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Image>().enabled = false;
        }

        nCurrentImage = 0;
    }

    //Ends te DocumentViewer UI
    public void Resume()
    {
        //Time.timeScale = 1;
        objBackground.SetActive(false);
        player.enabled = true;

        Cursor.visible = false;
        Screen.lockCursor = true;
        this.gameObject.SetActive(false);
    }
}
