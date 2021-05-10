using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float life, stopDistance, initialSpeed;
    private float speed, distance;
    private bool isRight, isLeft, isDead, follow;
    Transform player;
    private Rigidbody2D rig;
    private BoxCollider2D box;
    private Animator anim;
    private SpriteRenderer spt;
    private AudioSource deadSound;

    // Start is called before the first frame update
    void Start()
    {
        speed = initialSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deadSound = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
        spt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        
        if(distance <= 6.5f) follow = true;
        else follow = false;

        if(distance <= stopDistance ){
            speed = 0;
        }
        else{
            speed = initialSpeed;
        }
        if(transform.position.x - player.position.x < 0){
            isRight = true;
        }
        else{
            isRight = false;
        }
    }
    void FixedUpdate(){
        if(isDead == false && follow){
            if(isRight){
                rig.velocity = new Vector2(speed, rig.velocity.y);
                transform.eulerAngles = new Vector2(0, 0);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                anim.SetInteger("transition", 0);
            }
            else{
                rig.velocity = new Vector2(-speed, rig.velocity.y);
                transform.eulerAngles = new Vector2(0, -180);
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.15f);
                anim.SetInteger("transition", 0);
            }
        }
        else{
            speed = 0;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.GetComponent<Player>().OnHit();
            anim.SetInteger("transition", 1);
        }
    }
    public void OnHit(){
        life --;
        if(life <= 0){
            deadSound.Play();
            isDead = true;
            box.enabled = false;
            speed = 0;
            spt.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
    public void IsDead(bool argument){
        isDead = argument;
    }
    public bool IsDead(){
        return isDead;
    }
}
