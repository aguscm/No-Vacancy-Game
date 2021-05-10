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

    public GameObject selectionManager; //To enable o disable selectionManager so as not to interfere with the UI

    //Controlling mouse wheel
    private float scale = 1;

    public float minScale = 0.5f;

    public float maxScale = 7f;

    private float movementFactor = 0.25f;

    //Controlling canvas movement following the mouse

    private const float DIVISION = 400.0f;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        scale = minScale*3;
    }

    // Update is called once per frame
    void Update()
    {
        //Zoom in and out with mouse wheel
        if (scale < minScale)
        {
            scale = minScale;
        }
        else if (scale > maxScale)
        {
            scale = maxScale;
        }
        else
        {
            scale = scale + Input.mouseScrollDelta.y * 0.5f;
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
        if (Input.GetKeyDown(escape))
        {
            Resume();
        }

        //Canvas moves with the movement of pointer
        float width = Screen.width * rect.anchorMin.x;
        float height = Screen.height * rect.anchorMin.y;

        float xoffset = 0;
        float yoffset = 0;

        if (Screen.width > 1024)
        {
            float difference = Screen.width - 1024;
            float percentage =
                (Input.mousePosition.x / (float) Screen.width) * 100;
            xoffset = (percentage * difference) / DIVISION;
        }
        if (Screen.height > 768)
        {
            float difference = Screen.height - 768;
            float percentage =
                (
                (float)(Screen.height - Input.mousePosition.y) /
                (float) Screen.height
                ) *
                100;
            yoffset = (percentage * difference) / DIVISION;
        }

        if (Screen.width < 1024)
        {
            float difference = 1024 - Screen.width;
            float percentage =
                (Input.mousePosition.x / (float) Screen.width) * 100;
            xoffset = -(percentage * difference) / DIVISION;
        }

        if (Screen.height < 768)
        {
            float difference = 768 - Screen.height;
            float percentage =
                (
                (float)(Screen.height - Input.mousePosition.y) /
                (float) Screen.height
                ) *
                100;
            yoffset = -(percentage * difference) / DIVISION;
        }

        rect.anchoredPosition =
            new Vector2((Input.mousePosition.x - width - xoffset) *
                movementFactor,
                (Input.mousePosition.y - height + yoffset) * movementFactor);
    }

    public void ShowImages(Image[] imagesToShow)
    {
        //Block the movement of the player
        
        Screen.lockCursor = false;
        Cursor.visible = false;
        player.enabled = false;
        selectionManager.SetActive(false);

        //Shows the background color of the canvas
        objBackground.SetActive(true);

        //Wipes the screen of all the previous images
        wipeScreen();

        //Shows the first image of the array
        this.imagesToShow = imagesToShow;
        imgCounter = imagesToShow.Length;
        imagesToShow[nCurrentImage].GetComponent<Image>().enabled = true;
        // Time.timeScale = 0;
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
        // Time.timeScale = 1;
        selectionManager.SetActive(true);
        objBackground.SetActive(false);
        player.enabled = true;

        //Cursor.visible = false;
        Screen.lockCursor = true;
        this.gameObject.SetActive(false);
    }
}
