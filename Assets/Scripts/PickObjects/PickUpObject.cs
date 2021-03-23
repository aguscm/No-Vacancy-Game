using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Pickable objectInHand;

    public Transform previousParentOfObject;

    public KeyCode drop;

    public bool inHand;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(drop))
        {
            dropObject();
        }
    }

    public void putObjectInHand(Pickable objectInHand)
    {
        this.objectInHand = objectInHand;
        objectInHand.rb.isKinematic = true;
        //Keep the previous parent of the object
        previousParentOfObject = objectInHand.transform.parent;

        //Now objectInHand is child of this GameObject
        objectInHand.gameObject.transform.parent = this.gameObject.transform;
        objectInHand.gameObject.transform.localPosition = new Vector3(0.8f, 0f, 0.8f);
        objectInHand.transform.tag = "Untagged";
        inHand = true;
    }

    public void dropObject()
    {
        //Restore the parent of the object
        objectInHand.transform.tag = "Selectable";
        objectInHand.gameObject.transform.parent = previousParentOfObject;
        objectInHand.rb.isKinematic = false;

        //Make null the object and its parent
        objectInHand = null;
        previousParentOfObject = null;
        
        inHand = false;
    }
}
