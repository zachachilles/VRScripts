using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script is used to color the children of a gameobject
public class ColorChildren : MonoBehaviour {
    GameObject thisObject;
	// Use this for initialization
	void Start () {
        thisObject = this.gameObject;
        int childNum = thisObject.transform.childCount; //first the number of children for the gameobject are calculated
        Color[] childColors = new Color[childNum]; //then an array is created to hold one color for each child
        int saturationIterator=0;
        bool valueAlternator = true; 
        for (int i = 0; i < childNum; i++)  //this loop generates a color for each child so they are equidistant based on hue and saturation
        {
            float onehun = 100;  
            Color color;
            float range = 100 / childNum; //each color is "range" apart 
            float hue = i * range; //the hue is set to be i times range 
            hue = hue / onehun; //this really could be /100f
            float saturation;
            float value = 1;
            if (saturationIterator<10) //this is just a way to change the saturation in a more distrubited way as hue alone is not enough to distinguish between children
            {
                saturation = saturationIterator * 7 + 30;
                saturation = saturation / onehun;                
            }
            else
            {
                saturationIterator = 0;
                saturation = 1.0f;
            }
            if (valueAlternator)
            {
                value = 0.5f;
                valueAlternator = false;
            }
            else
            {
                valueAlternator = true;
            }
            color = Color.HSVToRGB(hue, saturation, value); //this sets color to a new color generated from teh hue and saturation values
            childColors[i] = color; //this sets that new color to the childColors array
            saturationIterator++;
        }
        colorChildren(childColors); //plugs the generated array into the colorChildren class
    }
    void colorChildren (Color[] childColors) //called on line 46
    {
        int childNum = thisObject.transform.childCount; //gets the child count again
        for(int i = 0; i<childNum; i++) //iterates through and gets the Transform of each child and plugs into get renderer with the assocaited color
        {
            Transform firstChild = thisObject.transform.GetChild(i);
            findRenderer(firstChild, childColors[i]);
        }

    }
    public void findRenderer(Transform child, Color toColor) //called by colorChildren
    {
        if(child.GetComponent<Renderer>() != null)
        {
            child.GetComponent<Renderer>().material.color = toColor; //sets the color to the renderer of the child if it exists attached to the child Transform
        }
        else //otherwise the rendered is found by getting the child of the child and recursively calling back
        {
            int numChild = child.transform.childCount;
            for(int i = 0; i<numChild; i++)
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
