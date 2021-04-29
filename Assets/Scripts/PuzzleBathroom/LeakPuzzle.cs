using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakPuzzle : MonoBehaviour
{
    public int threshold = 4;

    public int currentCount = 0;

    public bool resolved;

    private AudioSource m_AudioSource;

    public GameObject ball;



    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void plusOne()
    {
        currentCount++;
        if (currentCount >= threshold)
        {
            resolved = true;
            ball.SetActive(true);
        }
    }

    public void playSound()
    {
        m_AudioSource.Play();
    }

    public void stopSound()
    {
        m_AudioSource.Stop();
    }

    public bool getIfResolved()
    {
        return resolved;
    }


}
