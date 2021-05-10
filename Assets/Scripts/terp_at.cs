using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terp_at : MonoBehaviour
{
    public float life;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        if(life<= 0) Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.GetComponent<Player>().OnHit();
        }
    }
}
