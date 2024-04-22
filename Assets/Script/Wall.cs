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
    Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (shrink) {
            float t = (Time.time - shrinkstart) ;
            if (t < shrinkDuration) {
                transform.localScale = new Vector3(originalScale.x, (1 - 0.2f * t / shrinkDuration) * originalScale.y, originalScale.z);
            } else if (t > shrinkDuration + effecttime && t < shrinkDuration + effecttime + restoreduration) {
                transform.localScale = new Vector3(originalScale.x, (0.8f + 0.2f * (t - shrinkDuration - effecttime) / restoreduration) * originalScale.y, originalScale.z);    //(0.8f + 0.2f * (t - shrinkDuration - effecttime) / restoreduration) * originalScale;
            } else if (t > shrinkDuration + effecttime + restoreduration) {
                transform.localScale = originalScale;
                shrink = false;
            }
        }
    }

    public void StartShrink() {
        shrink = true;
        shrinkstart = Time.time;
    }
}
