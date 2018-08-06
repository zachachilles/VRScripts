using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//certain meshes have a habit of being only generated on one side- they are invisible if looked at from the other side- this is a problem when objects can be picked up and rotated- this fixes that issue
public class FlipMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh; //the meshfilter component of the attached object is gotten
        mesh.triangles = mesh.triangles.Reverse().ToArray(); //they are then reveresed via this line
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void flip(GameObject objec) //this does the same as above except in a more useful way- this class can be called with an object that needs to be rendered on two sides
    {
        Mesh mesh = objec.GetComponent<MeshFilter>().mesh; 
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}
