using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//attach this script to a hemisphere of a brain to add the necessary components when play is pressed
//this script was used for the autism brain which is no longer present incorporated
public class AutismColorScript : MonoBehaviour {
    GameObject thisObject; //this is the object that gets initiated 
    public Material culloff;

    // Use this for initialization
    void Start () {
        thisObject = this.gameObject; //this sets the object to be the object the script is attached too
        int childNum = thisObject.transform.childCount; //this gets the number of children - this line is used to get the number of regions in the hemisphere
        for (int i = 0; i < childNum; i++)
        {
            Transform child = thisObject.transform.GetChild(i); //each region is grabbed
            Transform newchild = child.GetChild(0); //the actual functional Transform is really the child of an empty placeholder that is automatically generated upon import- this gets the Transform with the necessary components
            newchild.gameObject.AddComponent<Rigidbody>();
            newchild.gameObject.GetComponent<Rigidbody>().useGravity = true;
            newchild.gameObject.GetComponent<Rigidbody>().isKinematic = true; //the above add a rigidbody and the necesary components - these are required for interaction with the hands
            newchild.gameObject.AddComponent<MeshCollider>(); //this adds a meshcollider- allows the hands collider to know when interaction is occuring and thus when an object can be grabbed
            //  newchild.gameObject.GetComponent<SphereCollider>().radius = 4;
            newchild.transform.name = child.name; //this moves the name of the region from the empty placeholder to the functional Transform
     //       newchild.GetComponent<MeshRenderer>().material = culloff;

            //for adding original position script
            newchild.gameObject.AddComponent<resetScript>();
            newchild.gameObject.AddComponent<resetColor>(); //these add the two listed scripts to each functional group so they can be used
            resetScript go = newchild.GetComponent<resetScript>();
            resetColor col = newchild.GetComponent<resetColor>(); //these lines are necessary for actually using the newly attached scripts
            col.initialColor();
            go.initialPosition(); //these two lines set the initial qualties of the gameobjects so they can be reset when necessary


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
