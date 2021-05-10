using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abajur : MonoBehaviour
{
    public GameObject gema_verde;
    private bool interact = false;
    public Light luz;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(Input.GetKeyDown("o") && interact){
                anim.SetInteger("transition", 1);
                luz.enabled = true;
                Instantiate(gema_verde, transform.position, transform.rotation);
            }
        }
    }

    public void setInteract(bool arg){
        interact = arg;
    }
}
