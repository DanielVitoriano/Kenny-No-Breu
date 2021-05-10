using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cama : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") anim.SetInteger("transition", 1);
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player") anim.SetInteger("transition", 0);
    }
}
