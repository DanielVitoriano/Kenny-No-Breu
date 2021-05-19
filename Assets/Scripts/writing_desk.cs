using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class writing_desk : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Game_Controler gc;
    public Sprite closed;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Input.GetKeyDown("e")){
            sprite.sprite = closed;
            gc.interacoes ++;
            gameObject.tag = "Untagged";
        }
    }

}
