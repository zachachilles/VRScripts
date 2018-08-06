using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script exits the application if the escape key is pressed - basically ends the scene so the play button must be hit again
public class Exiting : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
}
