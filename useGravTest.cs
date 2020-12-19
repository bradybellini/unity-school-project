using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useGravTest : MonoBehaviour
{
    public gravController gC;
    public Button bounce;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<ConstantForce>().force = new Vector3(0, 9.81f-gC.grav, 0);
        bounce.onClick.AddListener(bounceBall);
    }

    void bounceBall()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0,250,0));
    }
}
