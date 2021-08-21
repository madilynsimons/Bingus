using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConveyorBeltService : MonoBehaviour
{
    private ConveyorBeltComponent m_conveyorBeltComponent;

    // Start is called before the first frame update
    void Start()
    {
        m_conveyorBeltComponent = GetComponent<ConveyorBeltComponent>();
        m_conveyorBeltComponent.TimeUntilNextBox = m_conveyorBeltComponent.SpawnTime;

        foreach (var point in m_conveyorBeltComponent.ConveyorBeltPoints)
        {
            var pointRenderer = point.GetComponent<Renderer>();
            //pointRenderer.enabled = false;
        }

        var belts = new GameObject[m_conveyorBeltComponent.ConveyorBeltPoints.Length - 1];
        
        for (int i = 0; i < m_conveyorBeltComponent.ConveyorBeltPoints.Length - 1; i++)
        {
            var beltSegment = GameObject.CreatePrimitive(PrimitiveType.Plane);
            
            var segmentComponent = beltSegment.AddComponent(typeof(ConveyorSegmentComponent)) as ConveyorSegmentComponent;
            segmentComponent.StartPoint = m_conveyorBeltComponent.ConveyorBeltPoints[i];
            segmentComponent.EndPoint = m_conveyorBeltComponent.ConveyorBeltPoints[i + 1];
            
            beltSegment.AddComponent(typeof(ConveyorSegmentService));
            belts[i] = beltSegment;
        }
        

        for (int i = 0; i < belts.Length; i++)
        {
            var transition = GameObject.CreatePrimitive(PrimitiveType.Plane);
            var transitionComponent = transition.AddComponent(typeof(ConveyorTransitionComponent)) as ConveyorTransitionComponent;
            transitionComponent.Point = belts[i].GetComponent<ConveyorSegmentComponent>().StartPoint;

            transition.AddComponent(typeof(ConveyorTransitionService));
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_conveyorBeltComponent.TimeUntilNextBox -= Time.deltaTime;
        if (m_conveyorBeltComponent.TimeUntilNextBox <= 0.0f)
        {
            CreateBox();
            m_conveyorBeltComponent.TimeUntilNextBox = m_conveyorBeltComponent.SpawnTime;
        }
    }

    private void CreateBox()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "ConveyorBeltBox";
        cube.AddComponent(typeof(ConveyorBoxService));
    }
}
