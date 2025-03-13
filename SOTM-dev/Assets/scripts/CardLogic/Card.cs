using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Canvas canvas;
    public bool isDragging = false;
    public UnityEvent<Card> BeginDragEvent;
    public UnityEvent<Card> EndDragEvent;
    public UnityEvent<Card> PointerEnterEvent;
    public UnityEvent<Card> PointerExitEvent;

    public bool selected;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDragEvent.Invoke(this);
        ResetCardPosition();
        isDragging = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterEvent.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExitEvent.Invoke(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void ResetCardPosition()
    {
        rectTransform.anchoredPosition = Vector3.zero;
    }

    public int ParentIndex()
    {
        return transform.parent.CompareTag("CardSlot") ? transform.parent.GetSiblingIndex() : 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
