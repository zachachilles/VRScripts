using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//if this script is attached to an object it prints the name of any objects that collide with it - however both objects must have a collider component attached and the object this is attached to must have the "ontriggerenter" option checked in the scene view under the options within the collider 
//I used this to test how the collision system works and what the various collision dimensions actually mean in a practical sense
public class CollisionPrinter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        print(other.GetComponent<Collider>().name);
    }
}
