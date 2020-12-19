using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballHitter : MonoBehaviour
{
    public baseballGame b;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ball")
        {
            b.ballHit(this.transform.up);
        }
    }
}
