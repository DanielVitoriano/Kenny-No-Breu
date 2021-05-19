using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controle_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sair(){
        Application.Quit();
    }
    public void iniciar(){
        SceneManager.LoadScene("SampleScene");
    }
    public void tutorial(){
        SceneManager.LoadScene("tutorial");
    }
}
