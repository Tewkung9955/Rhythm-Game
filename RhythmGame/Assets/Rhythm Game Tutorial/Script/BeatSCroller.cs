using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSCroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            /*if (Input.anyKey)
            {
                hasStarted = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
