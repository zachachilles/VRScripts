using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script is used to attach the appropriate scripts to the objects in the functional brain
public class FunctionalColors : MonoBehaviour {
    GameObject thisObject;
    public Material functionalculloff;
    // Use this for initialization
    void Start()
    {
        thisObject = this.gameObject; //first the game object is set
        int childNum = thisObject.transform.childCount; //next the number of children to be interacted with ie brain regions is got
        for (int i = 0; i < childNum; i++)
        {
            Transform child = thisObject.transform.GetChild(i); //the child Transform is grabbed
            Transform newchild = child.GetChild(0); //then the child of that - this is important because each child is essentially a placeholder for the real mesh containing child beneath it
            newchild.gameObject.AddComponent<Rigidbody>(); //a rigid body is added to allow them to be grabbed
            newchild.gameObject.GetComponent<Rigidbody>().useGravity = true; 
            newchild.gameObject.GetComponent<Rigidbody>().isKinematic = true;//this and the above line set the qualities of that rigid body
            newchild.gameObject.AddComponent<MeshCollider>();//a collider is added so the object can be grabbed via collider collisions
            //  newchild.gameObject.GetComponent<SphereCollider>().radius = 4;
            newchild.transform.name = child.name; //the mesh object is renamed so that the brain region name is on the transform that gets interacted with
            //       newchild.GetComponent<MeshRenderer>().material = culloff;
            newchild.gameObject.GetComponent<MeshRenderer>().material = functionalculloff; //this sets the material of the mesh to the functionalculloff material - necessary for allowing color changes among other things
            //for adding original position script
            newchild.gameObject.AddComponent<resetScript>();
            newchild.gameObject.AddComponent<resetColor>();
            newchild.gameObject.AddComponent<States>(); //the above add all the necessary scripts
            resetScript go = newchild.GetComponent<resetScript>();
            resetColor col = newchild.GetComponent<resetColor>(); //these too get the scripts so they can be called
            col.initialColor();
            go.initialPosition();//these call a class from each script getting initial values
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
