using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinalScene : MonoBehaviour
{
    public DoorController finalDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
          finalDoor.Interact();
          StartCoroutine(GoBackToMainMenu());
        }
    }

    IEnumerator GoBackToMainMenu() {
        yield return new WaitForSeconds(5);
        Cursor.visible = true;
        Screen.lockCursor = false;
        SceneManager.LoadScene("MainMenu");
    }
}
