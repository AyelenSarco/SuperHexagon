using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner spawnerHexagon;    
    [SerializeField] TMP_Text score_txt;
    [SerializeField] TMP_Text record_txt;
    [SerializeField] private AudioSource LoseSource;
    [SerializeField] private AudioSource PointSource;
    private int score;
    private static int record = 0;

    private void Start() {
        int record = PlayerPrefs.GetInt("record");
        score = 0;
        score_txt.text= score.ToString();
        record_txt.text = record.ToString();
        // Debug.Log("Score: " + score);
    }

   

    public void AddScore(){

       
        score_txt.text = (score += 100).ToString("");

        PointSource.Play();
        //Debug.Log("Score: " + score);
        HexagonVelocityHandle();
    }

    public void OnLose(){
        //Debug.Log("GAME OVER");  
        LoseSource.Play();
        CheckRecord();
        Invoke("GoToMenu",1);
        
       
    }

    public void CheckRecord(){
        if( score > PlayerPrefs.GetInt("record")) {
            PlayerPrefs.SetInt("record", score);
        }
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void HexagonVelocityHandle(){
        
        if (score != 0 && (score % 500 == 0 ) && (spawnerHexagon.GetSpawnTime() > 2f)){
            spawnerHexagon.SetSpawnTime(spawnerHexagon.GetSpawnTime() - 1f);
        }

        if (score % 1000 == 0){ 
           
            spawnerHexagon.SetRotate(true);
            spawnerHexagon.SetSpawnTime(spawnerHexagon.GetSpawnTime());
        } 
    }

}
