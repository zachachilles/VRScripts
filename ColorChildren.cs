using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I used this script to automatically color the children of whatever it is attached too- keep in mind this looks ugly  
public class ColorChildren : MonoBehaviour {
    GameObject thisObject;
	// Use this for initialization
	void Start () {
        thisObject = this.gameObject; //the object this is attached to are grabbed
        int childNum = thisObject.transform.childCount; //the children are also grabbed 
        Color[] childColors = new Color[childNum]; //an array containing a color for each child is generated
        int saturationIterator=0;
        bool valueAlternator = true; 
        for (int i = 0; i < childNum; i++) //this generates a color for each child with evenly spaced hues
        {
            float onehun = 100; //I did this so it is easier to change values later
            Color color;
            float range = 100 / childNum; //the distance in hue between each child
            float hue = i * range;
            hue = hue / onehun;
            float saturation;
            float value = 1;
            if (saturationIterator<10) //to make the colors more distinct the saturation value for each child is changed as well
            {
                saturation = saturationIterator * 7 + 30;
                saturation = saturation / onehun;                
            }
            else //every ten children have a distinct saturation until this is reset - saturation is less important than hue for uniqueness but the colors are too similiar if just hue is changed
            { 
                saturationIterator = 0; //basically there are 10 saturation values used and they are distributed to the children in order
                saturation = 1.0f;
            }
            if (valueAlternator) //this changes the value component of color as well- this change is also needed to make the colors more distinct
            {
                value = 0.5f;
                valueAlternator = false;
            }
            else //two values are used and these alternate between children
            {
                valueAlternator = true;
            }
            color = Color.HSVToRGB(hue, saturation, value); //a color is generated
            childColors[i] = color; //then set to fill the array
            saturationIterator++;
        }
        colorChildren(childColors); //this class is called to actually color the children
    }
    void colorChildren (Color[] childColors) //this class is necessary for the brain I used which has empty placeholders whose child is then a region - if you use a brain without these the children can be directly colored and this class is effectively useless
    {
        int childNum = thisObject.transform.childCount; 
        for(int i = 0; i<childNum; i++)
        {
            Transform firstChild = thisObject.transform.GetChild(i); //gets the child of the child - the child of the child actually contains the mesh and thus the practical portion of the region
            findRenderer(firstChild, childColors[i]); //calls this class which then actually changes the color of the mesh renderer
        }

    }
    public void findRenderer(Transform child, Color toColor) //actually changes the color
    {
        if(child.GetComponent<Renderer>() != null) //if there is a renderer
        {
            child.GetComponent<Renderer>().material.color = toColor; //change the color to the color that matches the array position above in childColors[] array
        }
        else //otherwirse
        {
            int numChild = child.transform.childCount;
            for(int i = 0; i<numChild; i++) //loop through the children of that to find the real renderer and then call the script again - this should never really be called 
            {
                Transform children = child.GetChild(i);
                findRenderer(children, toColor);
            }
        }

    }
    // Update is called once per frame
    void Update()    {

    }
}
