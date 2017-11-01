using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour {

    public float moveForce = 0f;
    private Rigidbody rBody;
    public Vector3 moveDir;
    public LayerMask whatIsWall;
    public float maxDistanceFromWall = 0f;
    public float sideDistanceFromWall = 0f;
    private Vector3 enemyPosition;

	// Use this for initialization
	void Start () {
        //Debug.Log("Q" + transform.position);
        rBody = GetComponent<Rigidbody>();
        moveDir = transform.forward;
        transform.rotation = Quaternion.LookRotation(moveDir);

        InvokeRepeating("SideCorridorCheck", 3.0f, 1.0f);

        enemyPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {

        rBody.velocity = moveDir * moveForce;

        if(Physics.Raycast(transform.position, -transform.forward, maxDistanceFromWall, whatIsWall))
        {
            ChangeDirection();
            Debug.Log("raycast back");
        }

        

    }

    private void SideCorridorCheck()
    {
        System.Random rand = new System.Random();

        int i = rand.Next(0, 5);

        if(i == 0)
        {
            //check right side
            if (!Physics.Raycast(transform.position, transform.right, sideDistanceFromWall, whatIsWall))
            {
                moveDir = -transform.right;
                transform.rotation = Quaternion.LookRotation(-transform.right);
            }

        }else if(i == 1)
        {
            //check left side
            if (!Physics.Raycast(transform.position, -transform.right, sideDistanceFromWall, whatIsWall))
            {
                moveDir = transform.right;
                transform.rotation = Quaternion.LookRotation(transform.right);
            }
        }


        
    }

    private void ChangeDirection()
    {
        moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    private Vector3 ChooseDirection()
    {
        System.Random rand = new System.Random();
        int i = rand.Next(0, 3);
        Vector3 direction = new Vector3();

        if(i == 0)
        {
            direction = transform.right;
            Debug.Log("right");
        }
        else if( i == 1)
        {
            direction = transform.forward;
            Debug.Log("forward");
        }
        else if( i == 2)
        {
            direction = -transform.right;
            Debug.Log("left");
        }else if (i == 3)
        {
            direction = -transform.forward;
            Debug.Log("back");
        }
        
        return direction;
    }

}
