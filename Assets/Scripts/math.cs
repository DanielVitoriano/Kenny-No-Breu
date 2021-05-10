using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class math : MonoBehaviour
{
    public GameObject gema_vermelha, pia;
    private int v_like, v_key, v_paw, v_ope1, v_ope2, opr1, opr2;
    private int value1, value2, value3, value4;
    public TextMeshProUGUI v1, v2, v3, operador1, operador2;
    public TMP_InputField player_input;
    public TMP_FontAsset fontAsset;
    void Awake(){

        
    }
    void Start()
    {
        refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void calcV4(){
        
        if(v_ope2 == 2){
            if(v_ope1 == 0){
                opr1 = v_like;
                value4 = opr1 + (v_paw * v_key);
            }
            else if(v_ope1 == 1){
                opr1 = v_like;
                value4 = opr1 - (v_paw * v_key);
                value4 = opr1 - (v_paw / v_key);
            }
            else if(v_ope1 == 2){
                opr1 = v_like * v_paw;
                value4 = opr1 * v_key;
                value4 = opr1 / v_key;
            }
            else {
                opr1 = v_like / v_paw;
                value4 = opr1 * v_key;
            }
        }
        else{
            opr2 = v_key;
            if(v_ope1 == 0) opr1 = v_like + v_paw;
            else if(v_ope1 == 1) opr1 = v_like - v_paw;
            else if(v_ope1 == 2) opr1 = v_like * v_paw;
            else opr1 = v_like / v_paw;

            if(v_ope2 == 0) value4 = opr1 + opr2;
            else if(v_ope2 == 1) value4 = opr1 - opr2;

        }
        Debug.Log(value4);
        
    }

    public void activeChallenge(){
        gameObject.SetActive(true);
    }
    private void refresh(){
        v_like = Random.Range(0, 100);
        v_key = Random.Range(0, 100);
        v_paw = Random.Range(0, 100);
        
        v_ope1 = Random.Range(0, 3);
        v_ope2 = Random.Range(0, 3);
        
        value1 = v_like + v_like;
        value2 = v_like + (v_paw * 3);
        value3 = (v_paw * 3) + (v_key * 2);

        v1.text = value1.ToString();
        v1.font = fontAsset;
        v2.text = value2.ToString();
        v2.font = fontAsset;
        v3.text = value3.ToString();
        v3.font = fontAsset;
         //valor do operador 1
        if(v_ope1 == 0 ){ //0 é soma
            operador1.text = "+";
        }
        else if(v_ope1 == 1){ //1 subtração
            operador1.text = "-";
        }

        else if(v_ope1 == 2){ //2 multi
            operador1.text = "X";
        }
        else{ // 3 div
            operador1.text = "/";
        }

        //valor do operador 2
        if(v_ope2 == 0 ){ //0 é soma
            operador2.text = "+";
        }
        else if(v_ope2 == 1){ //1 subtração
            operador2.text = "-";
        }

        else if(v_ope2 == 2){ //2 multi
            operador2.text = "X";
        }
        else{ // 3 div
            operador2.text = "/";
        }
        operador1.font = fontAsset;
        operador2.font = fontAsset;
        //somando valor 4
        calcV4();
    }

    public void checkResult(){
        string resp = player_input.text;
        int resp_int = int.Parse(resp);
        if(resp_int != value4){
            player_input.text = " ";
            refresh();
        }
        else{
            Instantiate(gema_vermelha, pia.transform.position, pia.transform.rotation);
            Destroy(gameObject);
        }
    }
}
