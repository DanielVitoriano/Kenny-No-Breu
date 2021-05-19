using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject parte1, parte2;
    private int parte;
    void Start()
    {
        parte = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(parte == 1){
            parte1.SetActive(true);
            parte2.SetActive(false);
        }
        else if(parte == 2){
            parte2.SetActive(true);
            parte1.SetActive(false);
        }
    }

    public void mudarParte(){
        parte ++;
        if(parte >= 3){
            SceneManager.LoadScene("menu");
        }
    }

}
