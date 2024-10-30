/**********************************************************************************************************************************************************
 * XRData_To
 * ---------
 *
 * 2021-09-05
 *
 * Converts from a normal variable to XRData
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface IXRData_To
{
    void Input(bool newValue);
    void Input(float newValue);
    void Input(int newValue);
    void Input(string newValue);
    void Input(Vector3 newValue);
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Connectors/XRData To")]
public class XRData_To : MonoBehaviour, IXRData_To
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public UnityXRDataEvent onChange;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Create an XRData of the right type.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Input (bool newValue)
    {
        if (onChange != null) onChange.Invoke(new XRData(newValue));
    }
    public void Input (float newValue)
    {
        if (onChange != null) onChange.Invoke(new XRData(newValue));
    }
    public void Input (int newValue)
    {
        if (onChange != null) onChange.Invoke(new XRData(newValue));
    }
    public void Input (string newValue)
    {
        if (onChange != null) onChange.Invoke(new XRData(newValue));
    }
    public void Input (Vector3 newValue)
    {
        if (onChange != null) onChange.Invoke(new XRData(newValue));
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}
