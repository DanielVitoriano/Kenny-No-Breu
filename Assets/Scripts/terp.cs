using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terp : MonoBehaviour
{
    public GameObject projetil;
    private Rigidbody2D rig;
    public float atackDistance, atackTime, walkDistance, speed;
    private Transform player;
    private float distance, timer, distance2, distance3;
    private Vector2 posA, posB;
    private bool right, left;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timer = atackTime;
        posA = new Vector2(transform.position.x - walkDistance, transform.position.y);
        posB = new Vector2(transform.position.x + walkDistance, transform.position.y);

        right = true;
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        //distance = Vector2.Distance(transform.position, player.position);
        distance2 = Vector2.Distance(transform.position, posB);
        distance3 = Vector2.Distance(transform.position, posA);
        //Debug.Log("distancia: " + distance2);

        if(distance <atackDistance){
            timer -= Time.deltaTime;
            if(timer <= 0){
                OnAttack();
                timer = atackTime;
            }
        }
        if(right){
            transform.eulerAngles = new Vector2(0f, 0f);
            rig.velocity = new Vector2(speed, rig.velocity.y);
            if(distance2 <= 1f){
                right = false;
                left = true;
            }
        }
        else if(left){
            transform.eulerAngles = new Vector2(0f, -180f);
            rig.velocity = new Vector2(-speed, rig.velocity.y);
            if(distance3 <= 1f){
                left = false;
                right = true;
            }
        }


    }

    private void OnAttack(){
        Instantiate(projetil, transform.position, transform.rotation);
    }

}
