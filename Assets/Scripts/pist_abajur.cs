using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pist_abajur : MonoBehaviour
{
    public abajur abj;
    private bool open = false;
    public GameObject image;
    public TMP_InputField playerInput;
    private string resp = "amuleto no abajur";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(Input.GetKeyDown("e")){
                if(!open){
                    open = true;
                    image.SetActive(true);
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(open){
                image.SetActive(false);
                open = false;
            }
        }
    }
    public void compareResp(){
        if(resp.Equals(playerInput.text)){
            playerInput.text = "CERTO";
            image.SetActive(false);
            abj.setInteract(true);
            abj.gameObject.tag = "interactive";
            Destroy(gameObject, 0.2f);
        }
        else{
            playerInput.text = "ERRADO";
        }
    }

}
