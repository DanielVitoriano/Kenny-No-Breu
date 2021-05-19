using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abajur : MonoBehaviour
{
    public GameObject gema_verde, jogador;
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
            if(Input.GetKeyDown("e") && interact){
                gameObject.tag = "Untagged";
                anim.SetInteger("transition", 1);
                luz.enabled = true;
                Instantiate(gema_verde, jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
            }
        }
    }

    public void setInteract(bool arg){
        interact = arg;
    }
}
