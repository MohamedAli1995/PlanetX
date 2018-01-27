using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron_motion : MonoBehaviour {

    /*
    public Transform center;
    public Vector3 axis = Vector3.up;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;*/
    // Use this for initialization
 /*   void Start () {
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }*/


    public float speed;
    public Transform target;
    public Vector3 positionToMove;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    public float distance;
    public float distanceFactor = 0.3f;
    public float positionFactor = 0.1f;
    private bool flag = true;
    void FixedUpdate()
    {
        while (flag)
        {
            if (Input.GetKey(KeyCode.Space)) flag = false;
            positionToMove = target.position - this.transform.position;
            distance = positionToMove.magnitude;
            transform.RotateAround(target.position, zAxis, speed * Time.deltaTime / (distance * distanceFactor));
            this.transform.position += positionToMove * Time.deltaTime * positionFactor;
        }

    }

}
/*
 
     #pragma strict
 
 public var center : Transform;
 public var axis   : Vector3 = Vector3.up;
 public var radius = 2.0;
 public var radiusSpeed = 0.5;
 public var rotationSpeed = 80.0; 
 
 function Start() {
     transform.position = (transform.position - center.position).normalized * radius + center.position;
 }
 
 function Update() {
     transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
     var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
     transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
 }
     */
