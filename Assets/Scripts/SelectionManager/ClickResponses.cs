using UnityEngine;

public class ClickResponses : MonoBehaviour, IClickResponse
{
    public void OnClick(Transform selection)
    {
        // Component OpenAndClose
        var doorController = selection.GetComponent<DoorController>();
        if (doorController != null)
        {
            doorController.Interact();
        }

        //Component BlackBoardPuzzle
        var blackBoardPuzzlePiece =
            selection.GetComponent<BlackboardPuzzlePiece>();
        if (blackBoardPuzzlePiece != null)
        {
            blackBoardPuzzlePiece.onClick();
        }

        //Component Light
        var light = selection.GetComponent<SwitchLight>();
        if (light != null)
        {
            light.Switch();
        }

        //Component Makesound
        var makeSound = selection.GetComponent<MakeSound>();
        if (makeSound != null)
        {
            makeSound.Play();
        }

        //Component changeTag
        //Best if this script is executed in the end
        var changeTag = selection.GetComponent<ChangeTag>();
        if (changeTag != null)
        {
            changeTag.changeTag();
        }
    }
}
