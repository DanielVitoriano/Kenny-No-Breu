using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Animator anim;
    public bool porta_trancada = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other){
        if(porta_trancada){
            if(other.gameObject.tag == "Player" && Input.GetKeyDown("e") && other.GetComponent<Player>().chave){
                anim.SetInteger("open", 1);
                gameObject.tag = "Untagged";
            }
        }
        else if(other.gameObject.tag == "Player" && Input.GetKeyDown("e")){
            anim.SetInteger("open", 1);
            gameObject.tag = "Untagged";
        }
        
    }
}
