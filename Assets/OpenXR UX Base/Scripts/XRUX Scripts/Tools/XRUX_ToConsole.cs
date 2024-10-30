/**********************************************************************************************************************************************************
 * XRUX_ToConsole
 * --------------
 *
 * 2021-09-28
 * 
 * Send XRData to the console.
 * 
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface IXRUX_ToConsole
{
    void Input(XRData theData);
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Tools/XRUX To Console")]
public class XRUX_ToConsole : MonoBehaviour, IXRUX_ToConsole
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------

    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private XRDeviceEvents eventQueue;  // The XR Event Queue
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Set up the variables ready to go.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        // Listen for events coming from the XR Controllers and other devices
        eventQueue = XRRig.EventQueue;
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Send the data to the console
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Input (XRData theData)
    {
        XREvent eventToSend = new XREvent();
        eventToSend.eventType = XRDeviceEventTypes.console;
        eventToSend.eventAction = XRDeviceActions.CHANGE;
        eventToSend.data = theData;
        if (eventQueue != null) eventQueue.Invoke(eventToSend);
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}

