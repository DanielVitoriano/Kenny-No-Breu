﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bau : MonoBehaviour
{
    public Game_Controler gc;
    public GameObject cadeado, chave;
    private Animator anim;
    private bool open = false, openned = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other){
        if(!openned && other.gameObject.tag == "Player" && Input.GetKeyDown("o") && gc.GetComponent<Game_Controler>().getGens() >= 4){
            cadeado.SetActive(true);
        }
        if(open && Input.GetKeyDown("o")){
            Instantiate(chave, transform.position, transform.rotation);
        }
    }
    public void setOpen(bool arg){
        open = arg;
    }
    public void setOpenned(bool arg){
        openned = arg;
    }
}
