using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script basically initializes the functionalBrain regions - add to regions that want to be treated like brain regions
public class FunctionalColors : MonoBehaviour {
    GameObject thisObject; //could also make this a class that takes an object as an input to be called from a initialize script - probably should make this transition  
    public Material functionalculloff; //this material does not have culling - this is vital for proper rendering 
    // Use this for initialization - attach to a hemisphere with regions attached
    void Start()
    {
        thisObject = this.gameObject; //the gameobject is not actually the one that contains the important components - it is the child of the child
        int childNum = thisObject.transform.childCount;
        for (int i = 0; i < childNum; i++)
        {
            Transform child = thisObject.transform.GetChild(i);
            Transform newchild = child.GetChild(0); //newchild actually contains the important components
            newchild.gameObject.AddComponent<Rigidbody>();
            newchild.gameObject.GetComponent<Rigidbody>().useGravity = true;
            newchild.gameObject.GetComponent<Rigidbody>().isKinematic = true; //rigid body is added and set up so the regions can be grabbed and interacted with
            newchild.gameObject.AddComponent<MeshCollider>(); //collider is also necessary for grabbing 
            //  newchild.gameObject.GetComponent<SphereCollider>().radius = 4;
            newchild.transform.name = child.name; //the name is moved from the empty placeholder to the gameobject that actually contains the mesh
            //       newchild.GetComponent<MeshRenderer>().material = culloff;
            newchild.gameObject.GetComponent<MeshRenderer>().material = functionalculloff; //uses the culloff material to render properly
            //for adding original position script
            newchild.gameObject.AddComponent<resetScript>();
            newchild.gameObject.AddComponent<resetColor>();
            newchild.gameObject.AddComponent<States>(); //adds the necessary scripts 
            resetScript go = newchild.GetComponent<resetScript>();
            resetColor col = newchild.GetComponent<resetColor>(); //sets up the scripts to be called
            col.initialColor();
            go.initialPosition(); //calls the scripts to initialize position and color - these can then be reset later
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
