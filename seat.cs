using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class seat : MonoBehaviour
{
    public newPlayerController p = null;
    public Canvas c;
    private void OnTriggerEnter(Collider other)
    {
        p = other.GetComponent<newPlayerController>();
        if (p)
        {
            p.isSeated = true;
            p.currSeat = 1;
            LeanTween.move(p.gameObject, this.transform.position, .5f);
            LeanTween.rotate(p.gameObject, this.transform.rotation.eulerAngles, .5f).setOnComplete(startGame);
        }
    }
    protected abstract void startGame();

    protected void endGame()
    {
        if(c)
            c.enabled = false;
        p.isSeated = false;
    }

    protected void update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            p.currSeat = -1;
            endGame();
        }
    }
}
