using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
//I used this script to test how the VRTK levers work 
//attach this script to the game object that has a VRTK lever attached 

public class EventManager : MonoBehaviour {
    public delegate void LeverAction();
    public static event LeverAction lever;
    public GameObject child;
	// Use this for initialization

	void Start () {
        VRTK_Lever l = child.GetComponent<VRTK_Lever>();

	}
    void lev()
    {
        bool triggered = false;
        VRTK_Lever l = child.GetComponent<VRTK_Lever>();
        float num = 45; //basically modify this value to test what numerical values correspond to an angle on the lever - it can be hard to tell what 45degrees is when you are twisting the levers around in 3d space basically
        if (l.CalculateValue() > num)
        {
            print("hello");
        }
    }

    // Update is called once per frame
    void Update () {
        VRTK_Lever l = child.GetComponent<VRTK_Lever>();
        float num = 45;
        
        if (l.CalculateValue() > num)
        {
            if (lever != null)
            {
                lever();
            }
        }
    }
}
