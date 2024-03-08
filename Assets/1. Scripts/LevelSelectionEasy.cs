using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionEasy : MonoBehaviour
{
    public Button[] lvlbuttons;
    public Text[] textBestScores;
    public GameObject View;
    public GameObject[] LockImages;
    public Sprite Lock;

    public GameObject Lock2;

    // 버튼 뷰
    public GameObject StartView1, StartView2, StartView3, StartView4, StartView5;

    [HideInInspector]
    public int levelAt;
    [HideInInspector]
    public int count;
    [HideInInspector]
    public int start;

    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("StageClearE1");
        start = PlayerPrefs.GetInt("Play");
        levelAt = PlayerPrefs.GetInt("levelAtE", 2);
        for (int i = 0; i < lvlbuttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                textBestScores[i].text = "";
                LockImages[i].SetActive(true);
            }
            else
            {
                textBestScores[i].text = $"{i + 1}스테이지 / 최고 점수 " + PlayerPrefs.GetInt("BestScoreE" + (i + 1).ToString()).ToString();
            }
        }
    }

    // 스테이지 화면에 스타트 버튼
    /*public void Stage0()
    {
        SceneManager.LoadScene(10);
    }*/

    public void Stage1()
    {
        StartView1.SetActive(true);
        StartView2.SetActive(false);
        StartView3.SetActive(false);
        StartView4.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage2()
    {
        StartView2.SetActive(true);
        StartView1.SetActive(false);
        StartView3.SetActive(false);
        StartView4.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage3()
    {
        StartView3.SetActive(true);
        StartView2.SetActive(false);
        StartView1.SetActive(false);
        StartView4.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage4()
    {
        StartView4.SetActive(true);
        StartView2.SetActive(false);
        StartView3.SetActive(false);
        StartView1.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage5()
    {
        StartView5.SetActive(true);
        StartView2.SetActive(false);
        StartView3.SetActive(false);
        StartView4.SetActive(false);
        StartView1.SetActive(false);
    }



    public void Btn1()
    {
        

        SceneManager.LoadScene(13);
        Time.timeScale = 1;
    }

    public void Btn2()
    {
        if (PlayerPrefs.GetInt("StageClearE1") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(14);
            Time.timeScale = 1;
        }
    }

    public void Btn3()
    {
        if (PlayerPrefs.GetInt("StageClearE2") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(15);
            Time.timeScale = 1;
        }
    }

    public void Btn4()
    {
        if (PlayerPrefs.GetInt("StageClearE3") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(16);
            Time.timeScale = 1;
        }
    }

    public void Btn5()
    {
        if (PlayerPrefs.GetInt("StageClearE4") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(17);
            Time.timeScale = 1;
        }
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseBtn()
    {
        View.SetActive(false);
    }

    // 홈버튼
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
    // 이전 버튼
    public void BeforeBtn()
    {
        SceneManager.LoadScene(11);
    }
}