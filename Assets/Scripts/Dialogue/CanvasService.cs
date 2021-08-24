using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasService : MonoBehaviour
{
    private CanvasComponent m_canvasComponent;
    private TextMesh m_textMesh;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_canvasComponent = GetComponent<CanvasComponent>();
        m_textMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_canvasComponent.CurrentDialogue == null)
        {
            SetVisibility(false);
        }
        else
        {
            SetVisibility(true);
            m_textMesh.text = m_canvasComponent.CurrentDialogue.Dialogue;
        }
    }

    private void SetVisibility(bool visible)
    {
        gameObject.GetComponent<Renderer>().enabled = visible;
        foreach (var child in gameObject.GetComponentsInChildren<Renderer>())
        {
            child.enabled = visible;
        }
    }
}
