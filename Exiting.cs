using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is a basic script that can be attached to anything - i normally would add it to the camera object - when the escape key is pressed the application exits
public class Exiting : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey("escape")) //could change this to change which key closes the program - could also change to by a button on the controllers to make it actually useful in the oculus
            Application.Quit();

    }
}
