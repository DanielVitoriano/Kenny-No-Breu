using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morra : MonoBehaviour
{
    public Game_Controler gc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            gc.RestartGame();
        }
    }
}
