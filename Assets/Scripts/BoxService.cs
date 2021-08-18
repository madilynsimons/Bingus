using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class BoxService : MonoBehaviour
{
    private ConveyorBeltComponent m_conveyorBeltComponent;

    private int m_iterator = 0;
    private bool m_isDestroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_conveyorBeltComponent = GameObject.FindWithTag("ConveyorBelt").GetComponent<ConveyorBeltComponent>();
        
        var startPosition = m_conveyorBeltComponent.ConveyorBeltPoints[m_iterator].transform.position;
        transform.position = startPosition;
        m_iterator++;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDestroyed)
        {
            return;
        }
        
        if (m_iterator >= m_conveyorBeltComponent.ConveyorBeltPoints.Length)
        {
            Destroy(gameObject);
            m_isDestroyed = true;
            return;
        }
        
        var targetPosition = m_conveyorBeltComponent.ConveyorBeltPoints[m_iterator].transform.position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            m_iterator++;
            return;
        }
        
        var step = m_conveyorBeltComponent.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
