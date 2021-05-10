﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.GetComponent<Player>().flashlight_sprite.enabled = true;
            other.GetComponent<Player>().setHaveFlashlight(true);
            other.GetComponent<Player>().setDrums(Random.Range(80, 100));
            Destroy(gameObject);
        }
    }
}
