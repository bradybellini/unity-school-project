using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drumController : MonoBehaviour
{
    private GameObject lastClick;
    public bool seated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (seated && Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if(hit.transform.parent==this.transform){
                lastClick = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<AudioSource>().Play();
                hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }   
        }
        if(!Input.GetMouseButton(0) && lastClick){
            lastClick.GetComponent<Renderer>().material.color = Color.white;
            lastClick = null;
        }
    }
}
