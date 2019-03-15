using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    KeyCode pressed;
    public bool slow=false;
    public float slowDownFactor = 8;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
            if (!slow)
            {
                Time.timeScale /= slowDownFactor;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                slow = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            slow = false;
        }
    }
}
