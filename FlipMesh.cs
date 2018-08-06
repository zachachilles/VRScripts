using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//this script is used to render both sides of meshes- normally only one side is rendered in unity- this made it so that if an object was picked up and rotated it would not render properly on the opposite side
public class FlipMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray(); //by reversing the mesh.triangles both sides are rendered 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void flip(GameObject objec) //this class is called to render both sides so the script doesn't need to be attached to everything at start
    {
        Mesh mesh = objec.GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}
