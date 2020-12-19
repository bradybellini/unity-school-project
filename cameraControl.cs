using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float speed = 1f;
    public float orbitDist;
    public float orbitHeight;
    public Vector3 focusPoint;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Mathf.Sin(Time.time * speed) * orbitDist, orbitHeight, Mathf.Cos(Time.time * speed) * orbitDist);
        this.transform.LookAt(focusPoint);
    }
}
