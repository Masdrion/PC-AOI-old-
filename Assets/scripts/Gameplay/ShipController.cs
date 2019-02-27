using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D rgbd;
    public Vector3 move;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        move=new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        move.y = Input.GetAxis("Vertical") * 8f;
        move.x = Input.GetAxis("Horizontal") * 8f;

        animator.SetInteger("move",(int) move.x);

        rgbd.AddForce(move*7,ForceMode2D.Force); //force movement option
        //rgbd.velocity = move; //velocity manipulation option

        //This part is for rotating the ship in the direction of movement
    }
}
