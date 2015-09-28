using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float smoothing;
    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerId;

    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerId)
        {
            Vector2 current = eventData.position;
            Vector2 directionRaw = current - origin;
            direction = directionRaw.normalized;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!touched)
        {
            touched = true;
            pointerId = eventData.pointerId;
            origin = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerId)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }

    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
