using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTrans;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    public int id; //id to match to place and draggable objectt
    private Vector3 initPos;
    public bool locked; //Lock the draggable object in place

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPos = transform.position; //Save starting position
        locked = false; //Unlock gameobjects
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!locked)
        {
            canvasGroup.blocksRaycasts = false;
            transform.SetAsLastSibling(); //Set gameobject at the front
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!locked)
        {
            rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor; //Follow position mouse
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!locked)
        {
            canvasGroup.blocksRaycasts = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Niks
    }
    public void ResetPosition()
    {
        transform.position = initPos; //Reset position gameobject back to starting position
    }
}
