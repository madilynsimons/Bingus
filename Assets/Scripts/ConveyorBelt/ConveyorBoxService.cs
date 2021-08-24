using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class ConveyorBoxService : MonoBehaviour
{
    private ConveyorBeltComponent m_conveyorBeltComponent;
    private Rigidbody m_rigidbody;
    private CharacterController m_controller;

    private int m_iterator = 0;
    private bool m_isDestroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_conveyorBeltComponent = GameObject.FindWithTag("ConveyorBelt").GetComponent<ConveyorBeltComponent>();

        var pointPosition = m_conveyorBeltComponent.ConveyorBeltPoints[m_iterator].transform.position;
        var initialBoxPosition = pointPosition + new Vector3(0, 1, 0);
        transform.position = initialBoxPosition;

        m_rigidbody = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            m_rigidbody.isKinematic = true;
        m_rigidbody.useGravity = true;

        m_controller = gameObject.AddComponent(typeof(CharacterController)) as CharacterController;
        
        m_iterator++;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDestroyed)
        {
            return;
        }
        
        // Try to destroy the game object
        if (m_iterator >= m_conveyorBeltComponent.ConveyorBeltPoints.Length)
        {
            Destroy(gameObject);
            m_isDestroyed = true;
            return;
        }
        
        // Try to move on to the next conveyor belt point
        var targetPosition = m_conveyorBeltComponent.ConveyorBeltPoints[m_iterator].transform.position;
        //if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            m_iterator++;
            return;
        }
        
        /*
        // Move towards the point
        var step = m_conveyorBeltComponent.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        */

       var directionalVector = Vector3.Normalize(targetPosition - transform.position);
        m_controller.Move(directionalVector * Time.deltaTime * 2.0f);

       /*
        if (directionalVector != Vector3.zero)
        {
            gameObject.transform.forward = directionalVector;
        }
        */
    }
}
