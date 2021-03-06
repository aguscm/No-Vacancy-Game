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
        var blackBoardPuzzlePiece = selection.GetComponent<BlackboardPuzzlePiece>();
        if (blackBoardPuzzlePiece != null)
        {
            blackBoardPuzzlePiece.onClick();
        }

    }
}
