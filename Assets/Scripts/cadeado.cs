using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cadeado : MonoBehaviour
{
    public TMP_InputField digito1;
    public GameObject bau;
    //public GameObject bau;
    private int password = 264;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkPass(){
        string PlayerInput = digito1.text;
        if(password == int.Parse(PlayerInput)){
            gameObject.SetActive(false);
            bau.GetComponent<bau>().setOpen(true);
            bau.GetComponent<bau>().setOpenned(true);
        }
        else{
            digito1.text = "123";
        }
    }
}
