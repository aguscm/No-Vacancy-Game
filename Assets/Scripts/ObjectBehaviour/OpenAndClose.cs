using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndClose : MonoBehaviour
{
    private Animator anim;

    public string animation1;

    //  public string animation2;
    public bool opened = false;

    public bool blocked;

    public AudioClip soundEnter;

    public AudioClip soundClose;

    private AudioSource audioSource;

    public string DisplayTextIfBlocked;

    public bool callFunctionIfOpened;

    public string functionToCall;

    public GameObject ObjectFunction;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        //Si tenemos las llaves y la puerta no está bloqueada
        if (!this.blocked)
        {
            if (this.opened == false)
            {
                //anim[animation1].speed = 1;
                anim.Play ("Base Layer.OpenDoor", 0, 0.25f);

                //Reproducimos el objeto audio asociado a la clase
                if (soundEnter != null)
                {
                    PlaySound(soundEnter);
                }
                this.opened = true;
            }
            else
            {
                // anim[animation1].speed = -1;
                // anim[animation1].time = anim[animation1].length;
                 anim.Play ("Base Layer.OpenDoor", 0, 0.25f);

                //Reproducimos el objeto audio asociado a la clase
                if (soundClose != null)
                {
                    PlaySound(soundClose);
                }
                this.opened = false;
            }
        }
        else
        {
            //Si la puerta está bloqueada, mostramos un mensaje
            // GameObject
            //     .Find("UI/Canvas/TextBox")
            //     .GetComponent<DisplayText>()
            //     .ShowText(DisplayTextIfBlocked);
        }
    }

    private void PlaySound(AudioClip sound)
    {
      audioSource.PlayOneShot(sound);
        
    }
}
