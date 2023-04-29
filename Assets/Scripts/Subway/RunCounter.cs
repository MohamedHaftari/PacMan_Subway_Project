using System;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class RunCounter : MonoBehaviour
{
    [SerializeField]TMP_Text runCounterText;
    [SerializeField] float runCounter;

    void Update()
    {
        runCounter += Time.deltaTime*2;
        runCounterText.text = String.Format("{0:0.00}", runCounter)+" m";
    }
}
