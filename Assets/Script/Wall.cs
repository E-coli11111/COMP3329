using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool shrink = false;
    public float shrinkstart = 0f;
    public float shrinkDuration = 1f;
    public float effecttime = 1f;
    public float restoreduration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shrink) {
            float t = (Time.time - shrinkstart) ;
            if (t < shrinkDuration) {
                transform.localScale = new Vector3(1, 1.2f - 0.5f * t, 1);
            } else if (t > shrinkDuration + effecttime && t < shrinkDuration + effecttime + restoreduration) {
                transform.localScale = new Vector3(1, 0.7f + 0.5f*(t - shrinkDuration - effecttime), 1);
            } else if (t > shrinkDuration + effecttime + restoreduration) {
                transform.localScale = new Vector3(1, 1.2f, 1);
                shrink = false;
            }
        }
    }

    public void StartShrink() {
        shrink = true;
        shrinkstart = Time.time;
    }
}
