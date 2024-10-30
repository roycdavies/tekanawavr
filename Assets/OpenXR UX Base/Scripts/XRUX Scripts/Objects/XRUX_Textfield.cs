/**********************************************************************************************************************************************************
 * XRUX_Textfield
 * --------------
 *
 * 2021-08-30
 *
 * An XR UX element to show text.
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
public interface IXRUX_Textfield
{
    void Clear(); // Clears the text field

    void Input(string newTitle); // Add some text
    void Input(float newTitle); // Add some text
    void Input(int newTitle); // Add some text
    void Input(bool newTitle); // Add some text
    void Input(Vector3 newTitle); // Add some text
    void Input(XRData newData); // Add some text

    void Send(); // Send the current collected text over the output
}
// ----------------------------------------------------------------------------------------------------------------------------------------------------------



// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Main class
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
[AddComponentMenu("OpenXR UX/Objects/XRUX Textfield")]
public class XRUX_Textfield : MonoBehaviour, IXRUX_Textfield
{
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Public variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public XRData.Mode mode = XRData.Mode.User; // For use in the inspector only
    public UnityXRDataEvent onSend; // Functions to call when the send is called
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Private variables
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    private TextMeshPro textDisplay;
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Change the text
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Input(float theItem) { Input (theItem.ToString()); }
    public void Input(int theItem) { Input (theItem.ToString()); }
    public void Input(bool theItem) { Input (theItem.ToString()); }
    public void Input(Vector3 theItem) { Input( XRData.FromVector3(theItem)); }
    public void Input(XRData theData) { Input (theData.ToString()); }

    public void Input(string theText)
    {
        if (textDisplay != null)
        {
            textDisplay.text = theText;
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Clear the text
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Clear()
    {
        if (textDisplay != null)
        {
            textDisplay.text = "";
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Send()
    {
        if (textDisplay != null)
        {
            if (onSend != null) onSend.Invoke(new XRData(textDisplay.text));
        }
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------



    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    // Set up the variables ready to go.
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        textDisplay = GetComponentInChildren<TextMeshPro>();
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
}
