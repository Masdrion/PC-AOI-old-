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

    public bool isFiring = false;
    public bool autofire = false;
    Coroutine firing;
    private void Update()
    {
        if (!autofire)
        {
            if (Input.GetKey(KeyCode.Z) && !isFiring)
            {
                isFiring = true;
                firing = StartCoroutine(shootBullets());
            }
            else if (!Input.GetKey(KeyCode.Z) && isFiring)
            {
                isFiring = false;
                StopCoroutine(firing);
            }
        }
        else {
            if (!isFiring) {
                isFiring = true;
                firing = StartCoroutine(shootBullets());
            }
        }
    }

    IEnumerator shootBullets() {
        while (true)
        {
            Vector3 bulletPosition= new Vector3(transform.position.x,transform.position.y,0);
            GameObject bullets = Instantiate(prefabBullets, bulletPosition, Quaternion.identity);
            Fire fire = bullets.GetComponent<Fire>();
            fire.FireAttack(direction * bulletSpeed);
            yield return new WaitForSeconds(bulletFiringTimer);
        }
    }
}
