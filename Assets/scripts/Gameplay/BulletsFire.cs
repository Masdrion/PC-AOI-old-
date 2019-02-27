using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFire : MonoBehaviour
{
    public GameObject bullet1, bullet2;

    public void FireBullet(Vector3 force) {
        bullet1.GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);
        bullet2.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
