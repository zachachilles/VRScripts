﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script is useless- should delete so this will never be read
public class FollowScript : MonoBehaviour
{

    public GameObject LeftHand;
    public GameObject LeftHandAvatar;

    // Use this for initialization
    void Start()
    {
        if (LeftHand == null)
            LeftHand = GameObject.Find("LeftHandAnchor");

        if (LeftHandAvatar == null)
            LeftHandAvatar = transform.Find("hand_left").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    //    transform.position += LeftHand.transform.position - LeftHandAvatar.transform.position;
    }
}
