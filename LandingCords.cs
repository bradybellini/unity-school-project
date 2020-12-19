using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LandingCords : MonoBehaviour
{
    public newPlayerController p;
    public Vector3 landingCords;
    public LongJump lj;
    public TextMeshProUGUI text;
    public Canvas c;
    float distance = 0;

    // public TextMeshProUGUI Text { get => text; set => text = value; }

    void OnTriggerEnter(Collider other)
    {
        lj = GameObject.Find("longJump").GetComponent<LongJump>();
        if (other.gameObject.CompareTag("Player"))
        {
            landingCords = p.transform.position;
            distance = landingCords[2] - lj.initialCords[2];
            Debug.Log(distance);

            text.text = "Jump Distance: " + distance.ToString();
            c.enabled = true;
            StartCoroutine(Instructions());


        }
    }
    IEnumerator Instructions()
    {
        //run instructions
        yield return new WaitForSecondsRealtime(5);
        c.enabled = false;
    }
}