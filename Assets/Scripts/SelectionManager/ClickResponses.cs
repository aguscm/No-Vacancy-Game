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

        // //Component BlackBoardPuzzle
        // var blackBoardPuzzlePiece =
        //     selection.GetComponent<BlackboardPuzzlePiece>();
        // if (blackBoardPuzzlePiece != null)
        // {
        //     blackBoardPuzzlePiece.onClick();
        // }

        //Component BlackBoardPuzzle
        var blackBoardPuzzlePiece =
            selection.GetComponent<BlackboardPiece>();
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

        //Component clockHandController
        var clockHandController = selection.GetComponent<ClockHandController>();
        if (clockHandController != null)
        {
            clockHandController.rotate();
        }

        //Component DocumentViewerUI
        var documentViewerUI = selection.GetComponent<DocumentViewerUI>();
        if (documentViewerUI != null)
        {
            documentViewerUI.EnterViewer();
        }

        //Component Pickable
        var pickable = selection.GetComponent<Pickable>();
        if (pickable != null)
        {
            pickable.pickUp();
        }

        //Component Pickable
        var makeObjectPop = selection.GetComponent<MakeObjectPop>();
        if (makeObjectPop != null)
        {
            makeObjectPop.pop();
        }

        //Component Unlockdoor
        var unlockDoor = selection.GetComponent<UnlockDoor>();
        if (unlockDoor != null)
        {
            unlockDoor.Unlock();
        }

        //Component showDialog
        var showDialog = selection.GetComponent<ShowDialog>();
        if (showDialog != null)
        {
            showDialog.appearDialogOnClick();
        }

        //Component sink
        var sink = selection.GetComponent<Sink>();
        if (sink != null)
        {
            sink.switchSink(true);
        }

        //Component Leak
        var leak = selection.GetComponent<Leak>();
        if (leak != null)
        {
            leak.Fix();
        }

        //Component valveController
        var valveController = selection.GetComponent<ValveController>();
        if (valveController != null)
        {
            valveController.Turn();
        }

        //Component safeNumber
        var safeNumber = selection.GetComponent<SafeNumber>();
        if (safeNumber != null)
        {
            safeNumber.onClick();
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
