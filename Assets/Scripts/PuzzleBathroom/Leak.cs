using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour
{
    public GameObject wrench;
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {   
        //If wrench object is active
        if (wrench) {
            //If the animation has stopped, stopts the particles and sets the wrench object to inactive
            if (wrench.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
                particles.Stop();
                wrench.SetActive(false);
            }
        }
        //If the particles have stopped, this game object sets to inactive
        if (particles.isStopped) {
            this.gameObject.SetActive(false);
        }
    }

    public void Fix() {
        //Set the wrench object to active state, with automatically activates its animator
        wrench.SetActive(true);
    }
}
