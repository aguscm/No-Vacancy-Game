using UnityEngine;

public class RayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable"; //To interact directly with objects (Ex. pick up object)
    [SerializeField] private string hoverableTag = "Hoverable"; //To interact indirectly with objects (Ex. show material if flashlight UV is on)
    
    private Transform _selection;

    public void Check(Ray ray)
    {
        _selection = null;

        if (!Physics.Raycast(ray, out var hit, 4f)) return;
        
        var selection = hit.transform;
        if (selection.CompareTag(selectableTag) || selection.CompareTag(hoverableTag))
        {
            _selection = selection;
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}