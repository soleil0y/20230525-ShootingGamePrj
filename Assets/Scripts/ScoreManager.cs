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
            return currentScore; //�������� ��ȯ
        }
        set 
        { 
            currentScore = value; //��������.. value
            currentScoreUI.text = "SCORE : " + currentScore; //�ؽ�Ʈ ����-��������

            if (currentScore > bestScore) //���� �ְ��������� ũ�ٸ�
            {
                bestScore = currentScore; //bS=cS
                bestScoreUI.text = "BEST : " + bestScore; //�ؽ�Ʈ ����-�ְ�����
                PlayerPrefs.SetInt("Best Score", bestScore); //����(�ؽøʰ�ư...)
            }

        }
    }

    void Start()
    {
        //PlayerPrefs.SetInt("Best Score", 0); //�ʱ�ȭ������ ��������

        bestScore = PlayerPrefs.GetInt("Best Score", 0); //����� ����Ʈ���ھ�

        bestScoreUI.text = "BEST : " + bestScore;
    }

    void Update()
    {
        heartScoreUI.text = "LIFE : " + PlayerMove.playerHeart;
    }
}
