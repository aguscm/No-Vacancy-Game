using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    public ColorPiece[] colorPieces;

    public PositionPiece[] positionPieces;

    public bool isPuzzleBeaten;

    private AudioSource m_audioSource;

    [Space(10)]
    [Header("Interaction with External Objects")]
    public GameObject newspapersToActivate;

    public Renderer mannequinLeftEnd;

    public Renderer mannequinMiddleLeft;

    public Renderer mannequinMiddle;

    public Renderer mannequinMiddleRight;

    public Renderer mannequinRightEnd;

    public Material materialNeutral;

    public Material materialOrange;

    public Material materialBlue;

    public Material materialGreen;

    public Material materialPurple;

    public Material materialRed;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool checkIfWin()
    {
        foreach (ColorPiece colorpiece in colorPieces)
        {
            if (colorpiece.currentValue != colorpiece.correctValue)
            {
                return false;
            }
        }

        foreach (PositionPiece positionPiece in positionPieces)
        {
            if (positionPiece.currentValue != positionPiece.correctValue)
            {
                return false;
            }
        }

        return true;
    }

    public void checkPuzzle()
    {
        changeMannequinColors();
        if (checkIfWin())
        {
            newspapersToActivate.SetActive(true);
            m_audioSource.Play();
        }
    }

    public void changeMannequinColors()
    {
        for (int i = 0; i < positionPieces.Length; i++)
        {
            Renderer mannequin = null;
            Material color = null;
            switch ((int) positionPieces[i].currentValue)
            {
                case 1:
                    mannequin = mannequinLeftEnd;
                    break;
                case 2:
                    mannequin = mannequinMiddleLeft;
                    break;
                case 3:
                    mannequin = mannequinMiddle;
                    break;
                case 4:
                    mannequin = mannequinMiddleRight;
                    break;
                case 5:
                    mannequin = mannequinRightEnd;
                    break;
                default:
                    break;
            }

            switch ((int) colorPieces[i].currentValue)
            {
                case 1:
                    color = materialOrange;
                    break;
                case 2:
                    color = materialBlue;
                    break;
                case 3:
                    color = materialGreen;
                    break;
                case 4:
                    color = materialPurple;
                    break;
                case 5:
                    color = materialRed;
                    break;
                default:
                    color = materialNeutral;
                    break;
            }
            if (mannequin && color) {
                mannequin.material = color;
            }
            
        }
    }
}
