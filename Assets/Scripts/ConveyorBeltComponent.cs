using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltComponent : MonoBehaviour
{
    public float Speed { get; set; } = 2.0f;
    public float SpawnTime { get; } = 2.0f;
    public float TimeUntilNextBox { get; set; }

    [SerializeField] 
    private GameObject[] m_conveyorBeltPoints;
    public GameObject[] ConveyorBeltPoints
    {
        get => m_conveyorBeltPoints;
        set => m_conveyorBeltPoints = value;
    }
}
