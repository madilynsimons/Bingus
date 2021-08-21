using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ConveyorSegmentService : MonoBehaviour
{
    private ConveyorSegmentComponent m_conveyorSegmentComponent;
    private Rigidbody m_rigidbody;

    private Vector3 m_cachedStartPosition;
    private Vector3 m_cachedEndPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        m_conveyorSegmentComponent = GetComponent<ConveyorSegmentComponent>();

        m_cachedStartPosition = m_conveyorSegmentComponent.EndPoint.transform.position;
        m_cachedEndPosition = m_conveyorSegmentComponent.StartPoint.transform.position;
        
        m_rigidbody = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        m_rigidbody.isKinematic = true;
        m_rigidbody.useGravity = false;
        
        UpdateTransform();
    }
    
    // Update is called once per frame
    void Update()
    {
        var currentStart = m_conveyorSegmentComponent.StartPoint.transform.position;
        var currentEnd = m_conveyorSegmentComponent.EndPoint.transform.position;
        if (Vector3.Distance(m_cachedStartPosition, currentStart) > 0.1f
            || Vector3.Distance(m_cachedEndPosition, currentEnd) > 0.1f)
        {
            m_cachedStartPosition = currentStart;
            m_cachedEndPosition = currentEnd;

            UpdateTransform();
        }
    }

    private void UpdateTransform()
    {
        Vector3 endPosition = m_conveyorSegmentComponent.EndPoint.transform.position;
        Vector3 startPosition = m_conveyorSegmentComponent.StartPoint.transform.position;
        transform.position = Midpoint(startPosition, endPosition);

        Vector3 forwardDirection = startPosition - endPosition;
        Vector3 upDirection = FindUpDirection(startPosition, endPosition);
        Quaternion orientation = Quaternion.LookRotation(forwardDirection, upDirection);
        transform.rotation = orientation;

        //float scaleX = Vector3.Distance(startPosition, endPosition) / 10;
        float length = Vector3.Distance(startPosition, endPosition) / 12;
        transform.localScale = new Vector3(0.1f, 1, length);
    }

    private Vector3 FindUpDirection(Vector3 start, Vector3 end)
    {
        Vector3 tail = FindTail(start, end);
        Vector3 head = FindHead(start, end);
        Vector3 direction = head - tail;
        return direction;
    }

    private Vector3 FindTail(Vector3 start, Vector3 end)
    {
        float x = start.x;
        float z = start.z;

        float upperAngle = 90 - Mathf.Acos((end.y - start.y) / (end.x - start.x));
        float distanceBetweenStartAndEnd = Vector3.Distance(start, end);
        
        float y = (distanceBetweenStartAndEnd / 2) * Mathf.Cos(upperAngle);

        return new Vector3(x, y, z);
    }
    
    private Vector3 FindHead(Vector3 start, Vector3 end)
    {
        return Midpoint(start, end);
    }

    private Vector3 Midpoint(Vector3 lhs, Vector3 rhs)
    {
        float x = (lhs.x + rhs.x) / 2;
        float y = (lhs.y + rhs.y) / 2;
        float z = (lhs.z + rhs.z) / 2;
        return new Vector3(x, y, z);
    }
}
