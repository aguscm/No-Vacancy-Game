using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject objViewerMenu;
    public KeyCode activatePauseKey;
    public GameObject selectionManager; //To enable o disable selectionManager so as not to interfere with the UI
    public FirstPersonController player; //To activate o deactivate the player movements
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activatePauseKey)) {
            if (!pauseMenuUI.activeSelf && !objViewerMenu.activeSelf) {
                openPauseMenu();
            }else if (pauseMenuUI.activeSelf) {
                closePauseMenu();
            }

        }
    }

    public void openPauseMenu() {
        pauseMenuUI.SetActive(true);
        selectionManager.SetActive(false);
        player.enabled = false;
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    public void closePauseMenu() {
        pauseMenuUI.SetActive(false);
        selectionManager.SetActive(true);
        player.enabled = true;
        Cursor.visible = false;
        Screen.lockCursor = true;
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
