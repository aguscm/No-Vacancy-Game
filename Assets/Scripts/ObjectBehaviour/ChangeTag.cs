using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    private string previousTag;
    public string newTag;
    // Start is called before the first frame update
    void Start()
    {
        previousTag = gameObject.tag;
    }

    public void changeTag() {
        gameObject.tag = newTag;
    }
}
