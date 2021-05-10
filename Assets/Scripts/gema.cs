using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gema : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D col;
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void coletou(){
        col.enabled = false;
        anim.SetInteger("transition", 1);
        Destroy(gameObject, 2f);
    }
}
