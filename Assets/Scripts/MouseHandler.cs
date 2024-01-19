using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private float _radius;

    public Vector3 DragAndDrop()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 offset = mousePosition - _start.position;
        mousePosition = _start.position + Vector3.ClampMagnitude(offset, _radius);

        return mousePosition;
    }
}
