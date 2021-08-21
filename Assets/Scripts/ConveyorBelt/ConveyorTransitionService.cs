using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorTransitionService : MonoBehaviour
{
    private ConveyorTransitionComponent m_transitionComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        m_transitionComponent = GetComponent<ConveyorTransitionComponent>();
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        var pointPosition = m_transitionComponent.Point.transform.position;
        transform.position = pointPosition - new Vector3(0, 0.1f, 0);

        var rigidbody = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
