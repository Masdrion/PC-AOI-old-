using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D rgbd;
    public Vector3 move;
    public Animator animator;
    public float movementSpeed=14;
    public float slowingFactor = 2;

    [Header("TimeScale")]
    public bool changed = false;

    [Header("Dashing")]
    public float dashingFactor = 1;
    public float dashingTime = 0.1f;
    public bool dashing=false;

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

        rgbd.AddForce(move*movementSpeed,ForceMode2D.Force); //force movement option

        if (Time.timeScale < 1)
        {
            if(!changed){
                movementSpeed *= 3;
                dashingFactor = 5;
                changed = true;
            }
        }
        else
        {
            if (changed)
            {
                movementSpeed /= 3;
                dashingFactor = 1;
                changed = false;
            }
        }
        
        if (rgbd.velocity.y > 0)
        {
            if (move.y <= 0) {
                rgbd.AddForce(new Vector2(0,-1)*slowingFactor,ForceMode2D.Force);
            }
        }
        else if (rgbd.velocity.y < 0)
        {
            if (move.y >= 0)
            {
                rgbd.AddForce(new Vector2(0, 1)*slowingFactor, ForceMode2D.Force);
            }
        }

        if (rgbd.velocity.x > 0)
        {
            if (move.x <= 0)
            {
                rgbd.AddForce(new Vector2(-1, 0)*slowingFactor, ForceMode2D.Force);
            }
        }
        else if (rgbd.velocity.x < 0)
        {
            if (move.x >= 0)
            {
                rgbd.AddForce(new Vector2(1, 0)*slowingFactor, ForceMode2D.Force);
            }
        }
        //rgbd.velocity = move; //velocity manipulation option

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dashing)
            {
                movementSpeed *= (3*dashingFactor);
                dashing = true;
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(RevertBack());
            }
        }

    }
    IEnumerator RevertBack() {
        yield return new WaitForSeconds(dashingTime/dashingFactor);
        movementSpeed /= (3*dashingFactor);
        StartCoroutine(Invincibility());
        dashing = false;
    }
    IEnumerator Invincibility() {
        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().enabled = true;
    }
}
