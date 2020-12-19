using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smileController : MonoBehaviour
{
    public bool seated;
    public Canvas sliders;
    public Slider x,y,z;
    public GameObject smile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(seated){
            Camera.main.orthographic = true;
            sliders.enabled = true;
        }else{
            Camera.main.orthographic = false;
            sliders.enabled = false;
        }

        smile.transform.eulerAngles = new Vector3(x.value,y.value,z.value);
    }
}
