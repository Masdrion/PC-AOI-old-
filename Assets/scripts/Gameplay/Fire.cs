using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject[] attacks;
    GameObject player;
    bool isShot = false;
    [Header("Attack Timer")]
    public float timer = 1;

    public bool IsShot
    {
        get
        {
            return isShot;
        }

        set
        {
            isShot = value;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (!isShot)
        {
            if (player != null)
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        }
    }

    public void FireAttack(Vector3 force,string layer) {
        isShot = true;
        foreach(GameObject obj in attacks){
            obj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            obj.layer = LayerMask.NameToLayer(layer);
            obj.GetComponent<Rigidbody2D>().mass = 0;
        }
        StartDestroyTimer(timer);
    }

    public void StartDestroyTimer(float seconds) {
        StartCoroutine(AttackDestroy(seconds));
    }

    IEnumerator AttackDestroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
