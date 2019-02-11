using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullets;

    [Range(0f, 1f)]
    public float bulletFiringTimer = 1f;
    public float bulletSpeed = 0.5f;

    public Vector2 direction = new Vector2(0,1);

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(shootBullets());
    }


    IEnumerator shootBullets() {
        while (true)
        {
            yield return new WaitForSeconds(bulletFiringTimer);
            GameObject bullets = Instantiate(prefabBullets, transform.position, Quaternion.identity);
            bullets.GetComponent<BulletsFire>().FireBullet(direction * bulletSpeed);
        }
    }
}
