using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BlackboardPiece : MonoBehaviour
{
    public Blackboard blackboard;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public abstract void onClick();

    public void paintInBlackboard(string text)
    {
        this.GetComponent<TextMeshPro>().SetText(text);
    }
}
