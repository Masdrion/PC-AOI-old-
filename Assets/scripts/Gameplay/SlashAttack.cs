using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    [SerializeField]
    GameObject prefabSlash;
    GameObject attack;
    [Range(0f, 20f)]
    public float slashSpeed = 10f;

    public Vector2 direction = new Vector2(0, 1);
    
    bool attackStart = false;

    public float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (!attackStart)
            {
                attackStart = true;
                timer = 0;
                Vector3 attackPosition = new Vector3(transform.position.x, transform.position.y, 0);
                attack = Instantiate(prefabSlash, attackPosition, Quaternion.identity);
            }
            else
            {
                if (!attack.GetComponent<Fire>().IsShot)
                {
                    timer += Time.deltaTime;
                    attack.transform.localScale = new Vector3(1,1,1)*(1 + 0.5f*timer);
                    if (timer >= 1)
                    {
                        attack.GetComponent<Fire>().FireAttack(slashSpeed * direction);
                        StartCoroutine(PauseForSecondAttack());
                    }
                }
            }
        }
        else {
            attackStart = false;
            if (attack != null)
                if (!attack.GetComponent<Fire>().IsShot) {
                    Debug.Log("Destroying");
                    attack.GetComponent<Fire>().StartDestroyTimer(0.5f);
                }
        }
    }

    IEnumerator PauseForSecondAttack() {
        yield return new WaitForSeconds(1);
        attackStart = false;
    }
}
