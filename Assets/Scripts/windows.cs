using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windows : MonoBehaviour
{

    public GameObject gema_azul;
    private SpriteRenderer sprite;
    public Sprite windows_open;
    private Light light_windows;
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        light_windows = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(!open && other.gameObject.tag == "Player" && Input.GetKeyDown("o")){
            open = true;
            sprite.sprite = windows_open;
            light_windows.enabled = true;
            Instantiate(gema_azul, new Vector2(transform.position.x, transform.position.y - 2), transform.rotation);
        }
    }

}
