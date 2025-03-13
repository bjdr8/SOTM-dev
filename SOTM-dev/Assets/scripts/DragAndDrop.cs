using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public static event Action OnDroppingCard;
    public static event Action OnDraggingCard;
    public bool dragging;

    void Awake()
    {

    }

    void OnMouseDown()
    {
        dragging = true;        //so we know we are dragging something
        Debug.Log("Start");
        OnDraggingCard?.Invoke();       // invoking an action so other files know we are dragging
    }

    void OnMouseUp()
    {
        dragging = false;       // so we know we stopped dragging something
        Debug.Log("Stop");
        OnDroppingCard?.Invoke();       // invoking an action so other files know we stop with dragging
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z

        if (dragging)
        {
            this.transform.position = mouseWorldPos;
        }
    }
}
