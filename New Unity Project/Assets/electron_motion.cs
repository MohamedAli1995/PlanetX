using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron_motion : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    private float angle;
    public Transform target;
    public Vector3 positionToMove;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    public float distance;
    public float distanceFactor = 0.3f;
    public float positionFactor = 0.1f;
    public float movementSpeedFactor;
    public  float rotationDir;
    public Vector2 vel;
    private bool flag = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementSpeedFactor = 500f;
    }
    void OnTriggerEnter2D(Collider2D coll)   
    {
        if(coll.gameObject.tag=="proton_orbit")
        {

        
        GameObject parent = coll.gameObject.transform.parent.gameObject;
        if (parent.tag=="proton_active")
        {
            target = parent.transform;
            transform.up = target.position - transform.position;
            flag = true;
            positionToMove = this.transform.position - target.position;
            angle = Vector2.SignedAngle(new Vector2(positionToMove.x, positionToMove.y),
            new Vector2(this.transform.right.x, this.transform.right.y));
            Debug.Log(angle);
             rotationDir = 1;
            if (angle < 90f)
            {
                rotationDir = -1;
            }


            }
        }
        else if(coll.gameObject.tag == "proton_active")
        {
            Debug.Log("GAME OVER ");
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space)) flag = !flag;
        if (flag)
        {
            rb.velocity = new Vector3(0, 0, 0);
            positionToMove =  this.transform.position- target.position;
            distance = positionToMove.magnitude;
            //angle used to determine rotation direction 
            
            transform.RotateAround(target.position, zAxis* rotationDir, speed * Time.deltaTime / (distance * distanceFactor));
            this.transform.position -= positionToMove * Time.deltaTime * positionFactor;
        }
        else
        {
            //this.transform.position += this.transform.up * Time.deltaTime * movementSpeedFactor;
           rb.velocity = new Vector2(this.transform.right.x, this.transform.right.y) * movementSpeedFactor* Time.deltaTime;
            vel = rb.velocity;
        }
    }

}
