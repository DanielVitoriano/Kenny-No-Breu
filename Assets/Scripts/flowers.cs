using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowers : MonoBehaviour
{
    public Sprite flowers_open, flowers_closed;
    private bool open = false;
    public SpriteRenderer sprite_renderer;
    void Start()
    {
        //sprite_renderer.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(open){
            sprite_renderer.sprite = flowers_open;
        }
        else{
            sprite_renderer.sprite = flowers_closed;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "flashlight"){
            open = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "flashlight"){
            open = false;
        }
    }

}
