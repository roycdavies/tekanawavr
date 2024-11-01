/**********************************************************************************************************************************************************
 * XRUX_Console
 * ------------
 *
 * 2021-08-25
 *
 * A simple console where you can send strings, integers, floats or booleans and have them displayed.  Great for debugging in VR.
 *
 * Roy Davies, Smart Digital Lab, University of Auckland.
 **********************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Public functions
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
public interface IXRUX_Console
{
    void Clear(); // Clear the console

    void Input(Vector3 theItem); // Add line to the console
    void Input(string theItem); // Add line to the console
    void Input(int theItem); // Add line to the console
    void Input(float theItem); // Add line to the console
    void Input(bool theItem); // Add line to the console
    void Input(XRData theItem); // Add line to the console
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Objects/XRUX Console")]
public class XRUX_Console : MonoBehaviour, IXRUX_Console
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public int numLines = 20;
    public bool acceptGlobal = true;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private string[] linesOfText;
    private int currentLine = -1;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Overloaded Print functions for various types
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Input(Vector3 theItem) { Input (XRData.FromVector3(theItem)); }
    public void Input(float theItem) { Input (theItem.ToString()); }
    public void Input(int theItem) { Input (theItem.ToString()); }
    public void Input(bool theItem) { Input (theItem.ToString()); }
    public void Input(string theItem) { AddLineOfText(theItem); }
    public void Input(XRData theData) { AddLineOfText(theData.ToString()); }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Set up the variables ready to go.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        linesOfText = new string[numLines];
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Set up the link to the event manager
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        // Listen for events coming from the XR Controllers and other devices
        if (XRRig.EventQueue != null) XRRig.EventQueue.AddListener(onDeviceEvent);
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Refresh the display when turned on.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void OnEnable()
    {
        CommitToDisplay();
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Clear the display array and reset the currentLine position to the start
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Clear()
    {
        if (linesOfText != null)
        {
            for(int lineNumber = 0; lineNumber < numLines; lineNumber++)
            {
                linesOfText[lineNumber] = "";
            }
            currentLine = -1;
            CommitToDisplay();
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Add a new line of text to the display array, moving it all up from the bottom if necessary.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private void AddLineOfText(string theText)
    {
        if (linesOfText != null)
        {
            currentLine = currentLine + 1;
            if (currentLine >= numLines)
            {
                for(int lineNumber = 0; lineNumber < numLines-1; lineNumber++)
                {
                    linesOfText[lineNumber] = linesOfText[lineNumber+1];
                }
                currentLine = numLines-1;
            }
            linesOfText[currentLine] = theText;
            CommitToDisplay();
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Change the text in the display from the array of text
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private void CommitToDisplay()
    {
        if (linesOfText != null)
        {
            string theText = "";
            for(int lineNumber = 0; lineNumber < numLines; lineNumber++)
            {
                theText += linesOfText[lineNumber] + "\n";
            }
            XRUX_SetText textToChange = GetComponentInChildren<XRUX_SetText>(true);
            if (textToChange != null) textToChange.Input(theText);
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Global Console Events can be sent from anywhere
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private void onDeviceEvent(XREvent theEvent)
    {
        if ((theEvent.eventType == XRDeviceEventTypes.console) && (theEvent.eventAction == XRDeviceActions.CHANGE) && acceptGlobal)
        {
            AddLineOfText(theEvent.data.ToString());
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}
