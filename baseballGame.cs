using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class baseballGame : seat
{
    public GameObject bat, Ball;
    public Transform ballStart, batStart, ballAim;
    public float batSpeed;
    Rigidbody brb;
    bool ballInFlight = false;
    Vector3 camoffSet, camRotOffset;
    float highScore = 0;
    public TextMeshProUGUI text;
    protected override void startGame()
    {
        p.currSeat = 1;
        c.enabled = true;
        text.text = highScore.ToString();
        print("seated");
        brb = Ball.GetComponent<Rigidbody>();
        LeanTween.move(Ball, ballStart.position, 1f);
        bat.transform.position = batStart.position;
        bat.transform.rotation = batStart.rotation;
        camoffSet = Camera.main.transform.position - this.transform.position;
        camRotOffset = Camera.main.transform.eulerAngles - this.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        base.update();
        if (p.currSeat == 1)
        {
            if (Input.GetKeyDown(KeyCode.P) && !LeanTween.isTweening(Ball) && brb.isKinematic)
            {
                brb.isKinematic = false;
                brb.useGravity = false;
                brb.AddForce(Vector3.Normalize((ballAim.position - Ball.transform.position)) * 1000);
            }
            if (Input.GetKeyDown(KeyCode.R) && !LeanTween.isTweening(Ball) && !ballInFlight)
            {
                LeanTween.move(Camera.main.gameObject, this.transform.position + camoffSet, .5f);
                LeanTween.rotate(Camera.main.gameObject, this.transform.rotation.eulerAngles + camRotOffset, .5f);
                brb.isKinematic = true;
                LeanTween.move(Ball, ballStart.position, 1f);
                bat.transform.position = batStart.position;
                bat.transform.rotation = batStart.rotation;
            }
            if (Input.GetMouseButtonDown(0))
            {
                LeanTween.rotateAround(bat.gameObject, bat.transform.right, 360, 1 / batSpeed);
            }
            if (ballInFlight)
            {
                Camera.main.transform.position = Ball.transform.position - brb.velocity * .1f;
                Camera.main.transform.LookAt(Ball.transform.position);
            }
        }
    }

    public void ballHit(Vector3 dir)
    {
        float hitVel = 10f;
        brb.useGravity = true;
        ballInFlight = true;
        if (LeanTween.isTweening(bat.gameObject))
        {
            hitVel = 50f;
        }
        brb.velocity = Vector3.Normalize(brb.velocity.sqrMagnitude * dir) * hitVel;
    }

    public void ballGround()
    {
        if (ballInFlight)
        {
            float newScore = Vector3.SqrMagnitude(Ball.transform.position - this.transform.position);
            if (highScore < newScore)
                highScore = newScore;
            text.text = (highScore / 100).ToString();
        }
        ballInFlight = false;

    }
}
