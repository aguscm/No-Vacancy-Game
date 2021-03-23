using UnityEngine;

public interface IHoverResponse

{
    void OnSelect(Transform selection);
    void OnDeselect(Transform selection);
}
