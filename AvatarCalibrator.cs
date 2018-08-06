using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script is no longer used - it was used to initiate an earlier version of the hands if they were not properly set up in the unity scene view
public class AvatarCalibrator : MonoBehaviour
    {

        public GameObject LeftHand;
        public GameObject LeftHandAvatar;

    // Use this for initialization
    void Start()
    {
        if (LeftHand == null)
            LeftHand = GameObject.Find("LeftHandAnchor");
        if (LeftHandAvatar == null)
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
