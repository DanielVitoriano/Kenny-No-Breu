using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fechatudo : MonoBehaviour
{
    public GameObject math, cadeado, abajur;// gameover;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            math.gameObject.SetActive(false);
            cadeado.gameObject.SetActive(false);
            abajur.gameObject.SetActive(false);
            //gameover.gameObject.SetActive(false);
        }
    }
}
