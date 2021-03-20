using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*Makes an object appear or disappear
*/
public class MakeObjectPop : MonoBehaviour
{
    public GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pop()
    {
        StartCoroutine(popCoroutine());
    }

    IEnumerator popCoroutine()
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject obj in objs)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
            }
        }
    }
}
