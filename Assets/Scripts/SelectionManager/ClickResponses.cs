using UnityEngine;

public class ClickResponses : MonoBehaviour, IClickResponse
{
    public void OnClick(Transform selection)
    {
        // Component OpenAndClose
        var openAndClose = selection.GetComponent<OpenAndClose>();
        if (openAndClose != null)
        {
            openAndClose.Open();
        }

        //Component BlackBoardPuzzle
        var blackBoardPuzzlePiece = selection.GetComponent<BlackboardPuzzlePiece>();
        if (blackBoardPuzzlePiece != null)
        {
            blackBoardPuzzlePiece.onClick();
        }

    }
}
