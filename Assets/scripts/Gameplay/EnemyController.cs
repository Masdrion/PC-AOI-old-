using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ShootBullet shooter;
    public Animator animator;
    float HP=100;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void StartFire() {
        GetComponent<Collider2D>().enabled = true;
        shooter.autofire = true;
        animator.SetBool("move",true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Attacks"))
        {
            Destroy(collision.gameObject);
            HP -= 20;
            if (HP < 0)
                Destroy(gameObject);
        }
    }
}
