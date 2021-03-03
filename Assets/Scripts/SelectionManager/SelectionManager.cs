using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private IClickResponse _clickResponse;
    public KeyCode action;
    
    public Transform _currentSelection;

    public GameObject pointer;
    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
        _clickResponse = GetComponent<IClickResponse>();
    }

    private void Update()
    {
        if (_currentSelection != null) 
            _selectionResponse.OnDeselect(_currentSelection);
        
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();
        
        if (_currentSelection != null) {
            _selectionResponse.OnSelect(_currentSelection);
            if(pointer != null) {
                pointer.GetComponent<Image> ().enabled = true;
            }
            //When click, execute the action on IClickResponse
            if (Input.GetKeyDown(action)) {
                _clickResponse.OnClick(_currentSelection);
            }
        }else {
            if(pointer != null) {
             pointer.GetComponent<Image> ().enabled = false;
            }
        }
            
    }
}
