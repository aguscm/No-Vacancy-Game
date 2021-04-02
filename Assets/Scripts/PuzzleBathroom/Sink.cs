using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public ParticleSystem sinkParticle;

    public BathroomPuzzleController controller;

    private AudioSource m_AudioSource;

    public bool open;

    public bool startsOnPlay;

    public Sink sinkLeft;

    public Sink sinkRight;

    // Start is called before the first frame update
    void Start()
    {
        sinkParticle = GetComponent<ParticleSystem>();
        if (GetComponent<AudioSource>())
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        if (startsOnPlay)
        {
            sinkParticle.Play();
            m_AudioSource.Play();
            open = true;
        }
        else
        {
            sinkParticle.Stop();
            m_AudioSource.Stop();
            open = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void switchSink(
        bool multipleSinks
    )//Multiple sinks indicates if controlls the sinks in between

    {
        //Open and close the own sink
        if (sinkParticle.isPlaying)
        {
            sinkParticle.Stop();
            m_AudioSource.Stop();
            open = false;
        }
        else
        {
            sinkParticle.Play();
            m_AudioSource.Play();
            open = true;
        }

        if (multipleSinks == true)
        {
            //Open and close the immediate neighbor sinks
            if (sinkLeft != null) sinkLeft.switchSink(false);
            if (sinkRight != null) sinkRight.switchSink(false);
        }

        //Controls if the puzzle has been beaten
        controller.Control();
    }
}
