﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMoveCrate : physicsObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetVelocity = Vector2.left;
	}
}