using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I used this script to test the ontriggerenter built in function - the OnTriggerEnter class is activated when the "other" object enters the object with the OnTriggerEnter function active
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
