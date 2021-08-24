using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerService : MonoBehaviour
{
    private CharacterController m_characterController;
    private ControllerComponent m_controllerComponent;
    
    private void Start()
    {
        m_characterController = gameObject.GetComponent<CharacterController>();
        m_controllerComponent = gameObject.GetComponent<ControllerComponent>();
    }

    void Update()
    {
        m_controllerComponent.GroundedPlayer = m_characterController.isGrounded;
        if (m_controllerComponent.GroundedPlayer && m_controllerComponent.Velocity.y < 0)
        {
            var playerVelocity = m_controllerComponent.Velocity;
            playerVelocity.y = 0f;
            m_controllerComponent.Velocity = playerVelocity;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        m_characterController.Move(move * Time.deltaTime * m_controllerComponent.PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && m_controllerComponent.GroundedPlayer)
        {
            var playerVelocity = m_controllerComponent.Velocity;
            playerVelocity.y += Mathf.Sqrt(m_controllerComponent.JumpHeight * -3.0f * m_controllerComponent.GravityValue);
            m_controllerComponent.Velocity = playerVelocity;
        }

        {
            var playerVelocity = m_controllerComponent.Velocity;
            playerVelocity.y += m_controllerComponent.GravityValue * Time.deltaTime;
            m_controllerComponent.Velocity = playerVelocity;
        }
        
        m_characterController.Move(m_controllerComponent.Velocity * Time.deltaTime);
    }
}
