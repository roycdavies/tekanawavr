/**********************************************************************************************************************************************************
 * XRData_Integer
 * --------------
 *
 * 2021-09-05
 *
 * Sends an Integer when told to.
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface IXRData_Integer
{
    void Go();
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Connectors/XRData Integer")]
public class XRData_Integer : MonoBehaviour, IXRData_Integer
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public int value;
    public bool sendOnStart = false;
    public UnityXRDataEvent onChange;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private bool firstTime = true;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (firstTime)
        {
            firstTime = false;
            if (sendOnStart) Go();
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Send an Integer
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Go()
    {
        if (onChange != null) onChange.Invoke(new XRData(value));
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}
