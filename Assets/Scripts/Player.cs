using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject butInteragir;
    public float speed, life;// jump_force;
    public Game_Controler gc;
    public BoxCollider2D flashlight_area;
    public Image life_bar, flashlight_drums, chaveImage;
    public SpriteRenderer flashlight_sprite;
    private SpriteRenderer thisSprite;
    public Light flashlight;
    private Rigidbody2D rig;
    private Animator anim;
    //private bool isJumping = true;
    private float drums = 0;
    public bool flashlight_lit = false, have_flashlight, isDead = false, chave;
    private AudioSource walkSound;

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        have_flashlight = false;
        rig = GetComponent<Rigidbody2D>();
        //flashlight_area = GetComponent<BoxCollider2D>();
        flashlight_sprite.enabled = false;
        flashlight_area.enabled = false;
        flashlight.enabled = false;

        walkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")) butInteragir.SetActive(false);
        if(chave) chaveImage.enabled = true;
        life_bar.fillAmount = life/100;
        if(!isDead){
            if(Input.GetKeyDown("f")){
            Flashlight();
            }
            if(flashlight_lit){
                flashlight_drums.fillAmount = drums/100;
                drums -= 0.02f;
            }
            if(drums <= 0){
                flashlight_lit = false;
                flashlight_area.enabled = false;
                flashlight.enabled = false;
            } 
            Move();
            //Jump();
        }
        else{
            for(float i = 0; i <= 90; i += 0.01f){
                rig.transform.eulerAngles = new Vector3(0f, 0f, i);
            }
            isDead = true;
            speed = 0;
            anim.SetInteger("transition", 0);
            flashlight_sprite.enabled = false;
            have_flashlight = false;
            flashlight_area.enabled = false;
            flashlight.enabled = false;
        }

    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        if(Input.GetAxis("Horizontal") > 0) { //direita
            transform.eulerAngles = new Vector2(0f, 0f);
            flashlight.transform.position = new Vector3(transform.position.x + 0.84f, transform.position.y - 0.28f, -0.09f);
            anim.SetInteger("transition", 1);
            walkSound.Play();
        }
        if(Input.GetAxis("Horizontal") < 0) { //esquerda
            transform.eulerAngles = new Vector2(0f, -180f);
            flashlight.transform.position = new Vector3(transform.position.x -0.76f, transform.position.y + 0.28f * -1, 0.10f * -1);
            anim.SetInteger("transition", 1);
            walkSound.Play();
            
        }
        if(Input.GetAxis("Horizontal") == 0) { //parado
            anim.SetInteger("transition", 0);
        } 

    }

    /*void Jump(){
        if(Input.GetButtonDown("Jump") && isJumping == false){
            rig.AddForce(new Vector2(0f, jump_force));
            isJumping = true;
        }
    } */

    void Flashlight(){
        if(have_flashlight && !isDead && drums >= 0){
            
            if(flashlight_lit == false){ //se tiver desligada, liga
                flashlight_lit = true; //liga lanterna
                flashlight_area.enabled = true; //ativa a area de dano da lanterna
                flashlight.enabled = true; //ativa a luz da lanterna
            }
            else if(flashlight_lit == true){ //se tiver ligada, desliga
                flashlight_lit = false; //desliga a luz da lanterna
                flashlight_area.enabled = false; //desativa a area de dano da lanterna
                flashlight.enabled = false; // desativa a luz da lanterna
            }
        }
    }

    public void OnHit(){
        if(!isDead){
            life --;
            thisSprite.color = Color.red;
            if(life <= 0){
                isDead = true;
                gc.RestartGame();
                
            }
            StartCoroutine(OnWait(0.5f));
        }
       
    }
    IEnumerator OnWait(float wait){
        yield return new WaitForSeconds(wait);
        thisSprite.color = Color.white;
    }

    public void setHaveFlashlight(bool have){
        have_flashlight = have;
    }
    public void setDrums(float value){
        drums = value;
    }
    public float getLife(){
        return life;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "collectable"){
            other.GetComponent<BoxCollider2D>().enabled = false;
            gc.increaseGens();
            other.gameObject.GetComponent<gema>().coletou();
        }
        if(other.gameObject.tag == "interactive"){
            butInteragir.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "interactive"){
            butInteragir.SetActive(false);
        }
    }

}
