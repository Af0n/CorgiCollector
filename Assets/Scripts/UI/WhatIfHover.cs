using UnityEngine;
using UnityEngine.EventSystems;

public class WhatIfHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int bones;
    [Header("Unity Set Up")]
    public PopulateDisplay disp;

    public void OnPointerEnter(PointerEventData eventData)
    {
        disp.WhatIfDisplay(bones);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        disp.ResetWhatIf();
    }
}
