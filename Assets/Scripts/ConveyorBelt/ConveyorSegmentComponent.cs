using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ConveyorSegmentComponent : MonoBehaviour
{
    public GameObject StartPoint
    {
        get;
        set;
    }
    
    public GameObject EndPoint
    {
        get;
        set;
    }
}
