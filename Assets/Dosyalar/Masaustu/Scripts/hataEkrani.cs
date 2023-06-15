using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hataEkrani : MonoBehaviour , IDragHandler
{
    public Canvas Canvas;
    private RectTransform rectTransform1;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform1 = GetComponent<RectTransform>();

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform1.anchoredPosition += eventData.delta / Canvas.scaleFactor;
    }


}