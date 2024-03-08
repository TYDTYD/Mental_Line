using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlbuttons;
    public Text[] textBestScores;
    public GameObject View;
    public GameObject[] LockImages;

    public Sprite Lock;
    
    // 버튼 뷰
    public GameObject StartView1, StartView2, StartView3, StartView4, StartView5;

    [HideInInspector]
    public int levelAt;
    [HideInInspector]
    public int count;
    [HideInInspector]
    public int start;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("StageClear1");
        start= PlayerPrefs.GetInt("Play");
        levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for(int i = 0; i<lvlbuttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                textBestScores[i].text = "";
                LockImages[i].SetActive(true);
            }
            else
            {
                textBestScores[i].text = $"{i+1}스테이지 / 최고 점수 " + PlayerPrefs.GetInt("BestScore"+(i+1).ToString()).ToString();
            }
        }
    }

    // 스테이지 화면에 스타트 버튼
    public void Stage1()
    {
        click.Play();
        StartView1.SetActive(true);
        StartView2.SetActive(false);
        StartView3.SetActive(false);
        StartView4.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage2()
    {
        click.Play();
        StartView2.SetActive(true);
        StartView1.SetActive(false);
        StartView3.SetActive(false);
        StartView4.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage3()
    {
        click.Play();
        StartView3.SetActive(true);
        StartView2.SetActive(false);
        StartView1.SetActive(false);
        StartView4.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage4()
    {
        click.Play();
        StartView4.SetActive(true);
        StartView2.SetActive(false);
        StartView3.SetActive(false);
        StartView1.SetActive(false);
        StartView5.SetActive(false);
    }

    public void Stage5()
    {
        click.Play();
        StartView5.SetActive(true);
        StartView2.SetActive(false);
        StartView3.SetActive(false);
        StartView4.SetActive(false);
        StartView1.SetActive(false);
    }

    

    public void Btn1()
    {


        click.Play();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Btn2()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear1") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 1;
        }
    }

    public void Btn3()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear2") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(4);
            Time.timeScale = 1;
        }   
    }

    public void Btn4()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear3") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(5);
            Time.timeScale = 1;
        }
    }

    public void Btn5()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear4") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(6);
            Time.timeScale = 1;
        }
    }

    public void BackBtn()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    public void CloseBtn()
    {
        click.Play();
        View.SetActive(false);
    }

    // 홈버튼
    public void HomeBtn()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }
    // 이전 버튼
    public void BeforeBtn()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }
}
