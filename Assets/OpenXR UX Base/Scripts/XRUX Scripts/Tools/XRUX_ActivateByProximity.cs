/**********************************************************************************************************************************************************
 * XRUX_ActivateByProximity
 * ------------------------
 *
 * 2021-09-26
 *
 * Sends an event when the camera comes close.
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface IXRUX_ActivateByProximity
{
    void Input(XRData newData);
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Tools/XRUX Activate By Proximity")]
public class XRUX_ActivateByProximity : MonoBehaviour, IXRUX_ActivateByProximity
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public float distance = 2.0f;                       // Proximity to activate at
    public XRDeviceEventTypes activateTrigger;          // Event to send when activating
    public XRDeviceActions activateAction;              // Action to send when activating
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private XRDeviceEvents eventQueue;                  // The XR Event Queue
    private bool triggered = false;                     // Whether triggered or not
    private XRData data;                                // The data to send
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Get access to the main event queue
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        // Listen for events coming from the XR Controllers and other devices
        eventQueue = XRRig.EventQueue;
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Set the input data
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Input(XRData newData)
    {
        data = newData;
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Watch the event queue and send 
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (Camera.main != null)
        {
            if ((Vector3.Distance(Camera.main.transform.position, this.transform.position) <= distance) && !triggered)
            {
                triggered = true;

                XREvent eventToSend = new XREvent();
                eventToSend.eventType = activateTrigger;
                eventToSend.eventAction = activateAction;
                eventToSend.data = data;

                if (eventQueue != null) eventQueue.Invoke(eventToSend);
            } 
            else if ((Vector3.Distance(Camera.main.transform.position, this.transform.position) > distance) && triggered)
            {
                triggered = false;     
            }
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}
