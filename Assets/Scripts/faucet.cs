using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faucet : MonoBehaviour
{
    public GameObject math;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Input.GetKeyDown("e")){
            gameObject.tag = "Untagged";
            anim.SetInteger("transition", 1);
            StartCoroutine(OnWait(1.8f));

        }
    }
    IEnumerator OnWait(float wait){
        yield return new WaitForSeconds(wait);
        math.SetActive(true);
    }
}
