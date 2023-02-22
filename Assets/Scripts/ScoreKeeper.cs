using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI finalScoreUI;
    public int score = 0;
    public GameObject EndCanvas;
    public GameObject ScoreCanvas;
    private int count = 4;

    void Start(){
        EndCanvas.SetActive(false);
    }

    void Update() {
        scoreUI.SetText(score.ToString());
        finalScoreUI.SetText(score.ToString());
        if(count==0){
            EndCanvas.SetActive(true);
            ScoreCanvas.SetActive(false);
            Time.timeScale=0;
        }
    }

    public void IncreseScore(){
        score++;
        count--;
    }

    public void decreaseScore(){
        score--;
    }

}
