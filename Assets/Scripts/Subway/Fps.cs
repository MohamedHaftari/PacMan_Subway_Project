using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps : MonoBehaviour
{
    [SerializeField] int fps;
    void Update()
    {
        Application.targetFrameRate = fps;  
    }
}
