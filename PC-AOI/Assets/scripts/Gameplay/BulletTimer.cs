using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    public float seconds=1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bulletDestroy());
    }

    IEnumerator bulletDestroy() {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
