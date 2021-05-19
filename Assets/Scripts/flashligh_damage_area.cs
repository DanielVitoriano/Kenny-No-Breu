using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashligh_damage_area : MonoBehaviour
{
    public Game_Controler gc;
    public GameObject jogador;
    private BoxCollider2D coll;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = jogador.GetComponent<Transform>().rotation;
        if(transform.rotation.y == 0){
            transform.position = new Vector2(jogador.GetComponent<Transform>().position.x + 1.25f, jogador.GetComponent<Transform>().position.y);
        }else{
            transform.position = new Vector2(jogador.GetComponent<Transform>().position.x - 1.3f, jogador.GetComponent<Transform>().position.y);
        }
    }
    
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            other.GetComponent<Enemy>().OnHit();
            if(other.GetComponent<Enemy>().IsDead()){
                gc.increaseKills();
            }
        }
    }
}
