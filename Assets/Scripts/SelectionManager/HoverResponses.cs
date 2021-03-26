using UnityEngine;

public class HoverResponses : MonoBehaviour, IHoverResponse
{
    public void OnSelect(Transform selection)
    {
        //Component MaterialReveal
        var materialReveal = selection.GetComponent<MaterialReveal>();
        if (materialReveal != null && materialReveal.uvLight.on == true)
        {
            materialReveal.Reveal();
        }
    }

    public void OnDeselect(Transform selection)
    {
        //Component MaterialReveal
        var materialUnreveal = selection.GetComponent<MaterialReveal>();
        if (materialUnreveal != null)
        {
            materialUnreveal.Unreveal();
        }
    }
}
