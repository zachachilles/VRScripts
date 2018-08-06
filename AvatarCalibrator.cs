using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script gets the left hand set up for use- it is not really in use currently 
public class AvatarCalibrator : MonoBehaviour
    {

        public GameObject LeftHand;
        public GameObject LeftHandAvatar;

    // Use this for initialization
    void Start()
    {
        if (LeftHand == null) //this if statement gets the lefthandanchor object and sets the LeftHand object equal to that
            LeftHand = GameObject.Find("LeftHandAnchor");
        if (LeftHandAvatar == null) //this if statement finds the hand_left object which the LeftHandAvatar object is set equal too
            LeftHandAvatar = GameObject.Find("hand_left");
        if (LeftHandAvatar == null)
        {
 //           print("mn");
        }
    }
    void Update()
        {
     //   print(LeftHandAvatar.transform.position);
     //   print(LeftHandAvatar.transform.position);
  //      if (LeftHand.transform.position != LeftHandAvatar.transform.position)
        {
 //           transform.position += LeftHand.transform.position - LeftHandAvatar.transform.position;
        }
        }
    }
