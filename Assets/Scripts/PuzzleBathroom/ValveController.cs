using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    public bool canBeTurned = false;

    public string textIfCant;

    private ShowDialog showDialog;

    public BathroomPuzzleController sinksPuzzle;

    public LeakPuzzle leakPuzzle;

    private Animator anim;

    public string boolAnim = "isTurning";

    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        showDialog = GetComponent<ShowDialog>();
        anim = GetComponent<Animator>();
        if (GetComponent<AudioSource>())
        {
            m_AudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Turn()
    {
        //If previous puzzles resolved
        if (canBeTurned == true)
        {
            anim.SetBool(boolAnim, true);
            m_AudioSource.Play();
            this.gameObject.tag = "Untagged";
        }else {
        //If not
        showDialog.appearDialog (textIfCant);
        }


    }

    public void checkPreviousPuzzles()
    {
        if (sinksPuzzle.getIfResolved() && leakPuzzle.getIfResolved())
        {
            canBeTurned = true;
        }
    }
}
