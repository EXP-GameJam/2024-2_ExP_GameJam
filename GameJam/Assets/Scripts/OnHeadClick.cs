using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHeadClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Gauge gauge;

    public void OnPointerDown(PointerEventData eventData)
    {
        gauge.PointerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gauge.PointerUp();
    }
}
