using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour
{
    public float speed = 1f;
    public float moveDist = 1;
    public float phaseShift = 0;
    private Vector3 startPos;

    private void Start()
    { 
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = startPos + new Vector3(0, moveDist + Mathf.Sin(Time.time * speed + phaseShift) * moveDist, 0);
    }
}
