using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text bestScoreUI;
    private int bestScore;
    public Text currentScoreUI;
    private int currentScore;
    public Text heartScoreUI;

    public static ScoreManager Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public int Score
    {
        get
        { 
            return currentScore; //현재점수 반환
        }
        set 
        { 
            currentScore = value; //현재점수.. value
            currentScoreUI.text = "SCORE : " + currentScore; //텍스트 갱신-현재점수

            if (currentScore > bestScore) //만약 최고점수보다 크다면
            {
                bestScore = currentScore; //bS=cS
                bestScoreUI.text = "BEST : " + bestScore; //텍스트 갱신-최고점수
                PlayerPrefs.SetInt("Best Score", bestScore); //저장(해시맵가튼...)
            }

        }
    }

    void Start()
    {
        //PlayerPrefs.SetInt("Best Score", 0); //초기화용으로 씀ㅇㅅㅇ

        bestScore = PlayerPrefs.GetInt("Best Score", 0); //저장된 베스트스코어

        bestScoreUI.text = "BEST : " + bestScore;
    }

    void Update()
    {
        heartScoreUI.text = "LIFE : " + PlayerMove.playerHeart;
    }
}
