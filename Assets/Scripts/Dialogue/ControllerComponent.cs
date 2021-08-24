using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerComponent : MonoBehaviour
{

    private Vector3 m_playerVelocity;

    public Vector3 Velocity
    {
        get => m_playerVelocity;
        set => m_playerVelocity = value ;
    }

    public bool GroundedPlayer { get; set; }
    public float PlayerSpeed { get; set; } = 2.0f;
    public float JumpHeight { get; set; } = 1.0f;
    public float GravityValue { get; set; } = -9.81f;
}
