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
        cube.AddComponent(typeof(BoxComponent));
        cube.AddComponent(typeof(BoxService));
    }
}
