using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    public bool isBlocked;
    private bool isOpen;
    public string textIfBlocked;
    [SerializeField] private AudioClip m_OpenSound;  // the sound played when a door opens.
    [SerializeField] private AudioClip m_CloseSound; // the sound played when a door closes.
    private AudioSource m_AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact() {
        if (!isBlocked) {
            if (!isOpen) {
                Open();
                isOpen = true;
                m_AudioSource.clip = m_OpenSound;
                m_AudioSource.Play();
            }else {
                Close();
                isOpen = false;
                m_AudioSource.clip = m_CloseSound;
                m_AudioSource.Play();
            }
        }
    }

    private void Open() {
        anim.SetBool("isOpening", true);
    }

    private void Close() {
        anim.SetBool("isOpening", false);
    }
}
