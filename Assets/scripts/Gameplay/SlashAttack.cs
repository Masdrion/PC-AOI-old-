using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashAttack : MonoBehaviour
{
    public GameObject prefabSlash;
    public Text waitText;

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
                if (attack != null)
                {
                    if (attackStart)
                    {
                        timer += Time.deltaTime;
                        attack.transform.localScale = new Vector3(1, 1, 1) * (1 + 0.5f * timer);
                        if (timer >= 1)
                        {
                            Debug.Log("Shooting");
                            attack.GetComponent<Fire>().FireAttack(slashSpeed * direction);
                            attack = null;
                            StartCoroutine(PauseForSecondAttack());
                        }
                    }
                }
                else {
                    if (attackStart)
                    {
                        waitText.text = "Wait";
                    }
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            if (attack != null) {
                attack.GetComponent<Fire>().StartDestroyTimer(0.5f);
                attack = null;
                StartCoroutine(PauseForSecondAttack());
            }
        }
    }

    IEnumerator PauseForSecondAttack() {
        yield return new WaitForSeconds(2);
        attackStart = false;
        waitText.text = "";
    }
}
