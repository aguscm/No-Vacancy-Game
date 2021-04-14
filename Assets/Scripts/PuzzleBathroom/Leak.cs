using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Leak : MonoBehaviour
{
    public GameObject wrench;

    private ParticleSystem particles;

    public LeakPuzzle puzzle;

    private FirstPersonController player;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        player =
            GameObject
                .FindWithTag("Player")
                .GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        //If wrench object is active
        if (wrench)
        {
            //If the animation has stopped, stopts the particles and sets the wrench object to inactive
            if (
                wrench
                    .GetComponent<Animator>()
                    .GetCurrentAnimatorStateInfo(0)
                    .normalizedTime >=
                1.0f
            )
            {
                puzzle.stopSound();
                particles.Stop();
                wrench.SetActive(false);

                player.enabled = true; //Resumes the player movement
            }
        }

        //If the particles have stopped, this game object sets to inactive
        if (particles.isStopped)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Fix()
    {
        //Set the wrench object to active state, with automatically activates its animator
        puzzle.playSound();
        player.enabled = false; //Stops the player movement
        wrench.SetActive(true);

        StartCoroutine("plusOne");
    }

    IEnumerator plusOne()
    {   
        yield return new WaitForSeconds(2f);
        //Adds 1 to the puzzle controller
        puzzle.plusOne();
    }
}
