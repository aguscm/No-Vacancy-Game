using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    private MakeObjectPop pop;

    // Start is called before the first frame update
    void Start()
    {
        pop = GetComponent<MakeObjectPop>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            pop.pop();
        }
    }
}
