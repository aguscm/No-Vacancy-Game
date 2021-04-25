using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeControllerPuzzle : MonoBehaviour
{
    public int[] possibleValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public int[] correctValues = { 7, 5, 4, 9, 1 };

    public SafeNumber[] numbers;
    public SafeNumber button;

    public bool puzzleCompleted = false;

    private AudioSource m_AudioSource;

    public AudioClip m_Success;
    public AudioClip m_Failure;

    public DoorController doorSafe;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int[] getPossibleValues()
    {
        return possibleValues;
    }

    public bool checkPuzzle()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].getValue() == correctValues[i])
            {
                continue;
            }
            else
            {
                playSound(m_Failure);
                return false;
            }
            
        }
        puzzleCompleted = true;
        playSound(m_Success);
        doorSafe.Unlock();
        

        //Deactivate the numbers
        foreach (SafeNumber number in numbers) {
            number.gameObject.tag = "Untagged";
        }
        button.gameObject.tag = "Untagged";
        return true;
    }

    private void playSound(AudioClip sound) {
        m_AudioSource.clip = sound;
        m_AudioSource.Play();
    }
}
