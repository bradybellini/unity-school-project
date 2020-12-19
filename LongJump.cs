using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : MonoBehaviour
{
    // public Transform player;
    public newPlayerController p;
    public LandingCords lc;
    public Vector3 initialCords;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            initialCords = p.transform.position;

            // Debug.Log(initialCords);
        }
    }

    //void Update()
    //{
    //    lc = GameObject.Find("LandingCordsPlane").GetComponent<LandingCords>();
    //    Vector3 zero = new Vector3(0, 0, 0);
    //    if (!(lc.landingCords.Equals(zero)))
    //    {
    //        // Debug.Log(lc.landingCords[2] - initialCords[2]);
    //    }
    //}
}