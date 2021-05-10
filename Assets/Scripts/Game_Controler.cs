using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game_Controler : MonoBehaviour
{
    public int interacoes;
    public GameObject blob, kejoo, soot, bau, gema_amarela;
    private Vector2 pos_blob, pos_kejoo, pos_soot;
    public GameObject game_over;
    public TextMeshProUGUI gameText;
    public float timer,respTime;
    private float respTime_init;
    public TextMeshProUGUI timer_text, kills_text, gens_text;
    private int kills, gens;
    private bool have_key, menu_open, gemaIns = false;
    //public Text you_die;
    void Start()
    {
        respTime_init = respTime;
        InstantiateEnemys();
    }

    // Update is called once per frame
    void Update()
    {
        if(interacoes >= 2 && kills >= 3 && !gemaIns) {
            Instantiate(gema_amarela, transform.position, transform.rotation);
            gemaIns = true;
        }
        if(gens >= 4){
            bau.SetActive(true);
        }
        respTime -= Time.deltaTime;
        if(respTime <= 0){
            respTime = respTime_init;
            InstantiateEnemys();
        }
        if(Input.GetKeyDown("q") && menu_open) {
            game_over.SetActive(false);
            menu_open = false;
        }
        else if(Input.GetKeyDown("q") && !menu_open){
            menu_open = false;
            game_over.SetActive(true);
        }

        if(timer >= 0){
            timer -= Time.deltaTime;
            timer_text.text = timer.ToString("f0");
        }
        else RestartGame();
    }
    IEnumerator OnWait(float wait){
        yield return new WaitForSeconds(wait);
        Application.Quit();
    }
    public void Quit(){
        GameOver();
        StartCoroutine(OnWait(1.5f));
    }
    public void GameOver(){
        gameText.enabled = true;
        game_over.GetComponentInChildren<Animator>().SetInteger("transition", 1);
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void increaseKills(){
        kills++;
        kills_text.text = "x" + kills.ToString();
    }
    public void increaseGens(){
        gens++;
        gens_text.text = "x" + gens.ToString();
    }
    private void InstantiateEnemys(){
        setEnemyPos();
        Instantiate(blob, blob.GetComponent<Transform>().position = pos_blob, blob.GetComponent<Transform>().rotation);
        Instantiate(kejoo, kejoo.GetComponent<Transform>().position = pos_kejoo, kejoo.GetComponent<Transform>().rotation);
        Instantiate(soot, soot.GetComponent<Transform>().position = pos_soot, soot.GetComponent<Transform>().rotation);
    }
    private void setEnemyPos(){
        pos_blob = new Vector2(Random.Range(12f , 81f), -1);
        pos_kejoo = new Vector2(Random.Range(12f ,80f), -1.2f);
        pos_soot = new Vector2(Random.Range(12f, 81f), -1.4f);
    }
    public int getGens(){
        return gens;
    }
}
