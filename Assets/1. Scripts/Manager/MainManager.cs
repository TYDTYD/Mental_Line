using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainManager : MonoBehaviour
{
    // ����
    public GameObject SettingView;
    public GameObject HelpView;

    // ����
    public GameObject EscapeView;

    // ����
    [SerializeField] AudioSource music;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject sfxOn;
    public GameObject sfxOff;
    public GameObject shakeOn;
    public GameObject shakeOff;

    // ���Ĺ� ������� ����
    public Text Dopamine;
    public Text Serotonin;
    private int D;
    private int S;

    // �⼮üũ �� / ��ư
    public Button[] DayBtns;
    public GameObject DayView;
    public GameObject View1;
    public GameObject View2;
    // �⼮üũ �Ϸ� �̹���
    public GameObject[] Btnimg;
    // ������ũ �ޱ� ��ư Ȱ��ȭ
    public GameObject[] GetBtn;
    public GameObject[] Get2_Btn;
    public Button[] GetBTN;
    public Button[] Get2_BTN;

    // *���� ��
    public GameObject Views1;
    public GameObject Views2;
    public GameObject Views3;
    public GameObject Views4;
    public GameObject Views5;
    public GameObject Views6;
    public GameObject Views7;

    // ����
    public AudioSource click;

    // day = ���� 00��
    DateTime day = DateTime.Today.AddDays(1);
    TimeSpan ts = new TimeSpan(10, 0, 0);
    DateTime Now = DateTime.Now;


    // Start is called before the first frame update
    void Start()
    {
        
        // ����
        PlayerPrefs.GetInt("sound", 1);
        PlayerPrefs.GetInt("sfx", 1);
        PlayerPrefs.GetInt("shake", 1);

        // ó�� �÷��� ����
        PlayerPrefs.GetInt("Play", 0);
        // �� �������� Ŭ���� ���� - �ϵ���
        PlayerPrefs.GetInt("StageClear1", 0);
        PlayerPrefs.GetInt("StageClear2", 0);
        PlayerPrefs.GetInt("StageClear3", 0);
        PlayerPrefs.GetInt("StageClear4", 0);
        PlayerPrefs.GetInt("StageClear5", 0);
        // �� �������� Ŭ���� ���� - �������
        PlayerPrefs.GetInt("StageClearE1", 0);
        PlayerPrefs.GetInt("StageClearE2", 0);
        PlayerPrefs.GetInt("StageClearE3", 0);
        PlayerPrefs.GetInt("StageClearE4", 0);
        PlayerPrefs.GetInt("StageClearE5", 0);
        // ���Ĺ�, ������� ����
        D=PlayerPrefs.GetInt("Dopamine", 0);
        S=PlayerPrefs.GetInt("Serotonin", 0);
        // �� �������� �ְ� ���� - �ϵ���
        PlayerPrefs.GetInt("BestScore1", 0);
        PlayerPrefs.GetInt("BestScore2", 0);
        PlayerPrefs.GetInt("BestScore3", 0);
        PlayerPrefs.GetInt("BestScore4", 0);
        PlayerPrefs.GetInt("BestScore5", 0);
        // �� �������� �ְ� ���� - �������
        PlayerPrefs.GetInt("BestScoreE1", 0);
        PlayerPrefs.GetInt("BestScoreE2", 0);
        PlayerPrefs.GetInt("BestScoreE3", 0);
        PlayerPrefs.GetInt("BestScoreE4", 0);
        PlayerPrefs.GetInt("BestScoreE5", 0);
        // ������ ��Ų ����
        PlayerPrefs.GetInt("Item1", 0);
        PlayerPrefs.GetInt("Item2", 0);
        PlayerPrefs.GetInt("Item3", 0);
        PlayerPrefs.GetInt("Item4", 0);
        PlayerPrefs.GetInt("Item5", 0);
        // �ΰ����丮 �ر� ����
        PlayerPrefs.GetInt("Add1", 0);
        PlayerPrefs.GetInt("Add2", 0);
        PlayerPrefs.GetInt("Add3", 0);
        PlayerPrefs.GetInt("Add4", 0);
        PlayerPrefs.GetInt("Add5", 0);
        // ���罺�丮 ���� ����
        PlayerPrefs.GetInt("Hidden1", 0);
        PlayerPrefs.GetInt("Hidden2", 0);
        PlayerPrefs.GetInt("Hidden3", 0);
        PlayerPrefs.GetInt("Hidden4", 0);
        PlayerPrefs.GetInt("Hidden5", 0);
        // �⼮üũ ����
        PlayerPrefs.GetInt("Day1", 0);
        PlayerPrefs.GetInt("Day2", 0);
        PlayerPrefs.GetInt("Day3", 0);
        PlayerPrefs.GetInt("Day4", 0);
        PlayerPrefs.GetInt("Day5", 0);
        PlayerPrefs.GetInt("Day6", 0);
        PlayerPrefs.GetInt("Day7", 0);
        // ��¥ �ٲ�� ����
        PlayerPrefs.GetInt("DayCheck", 0);
        PlayerPrefs.GetInt("MonthCheck", 0);
        PlayerPrefs.GetInt("YearCheck", 0);
        // ��Ų ���� ����
        PlayerPrefs.GetInt("Fit0", 0);
        PlayerPrefs.GetInt("Fit1", 0);
        PlayerPrefs.GetInt("Fit2", 0);
        PlayerPrefs.GetInt("Fit3", 0);
        PlayerPrefs.GetInt("Fit4", 0);
        PlayerPrefs.GetInt("Fit5", 0);
        PlayerPrefs.GetInt("Fit6", 0);
        PlayerPrefs.GetInt("Fit7", 0);
        PlayerPrefs.GetInt("Fit8", 0);
        PlayerPrefs.GetInt("Fit9", 0);
        PlayerPrefs.GetInt("Fit10", 0);
        PlayerPrefs.GetInt("Fit11", 0);
        PlayerPrefs.GetInt("Fit12", 0);
        PlayerPrefs.GetInt("Fit13", 0);
        PlayerPrefs.GetInt("Fit14", 0);
        PlayerPrefs.GetInt("Fit15", 0);
        PlayerPrefs.GetInt("Fit16", 0);
        PlayerPrefs.GetInt("Fit17", 0);
        PlayerPrefs.GetInt("Fit18", 0);

        if (PlayerPrefs.GetInt("Play") == 0)
        {
            PlayerPrefs.SetInt("Fit0", 1);
        }
        

        Count();

        for (int i = 1; i < 7; i++)
        {
            DayBtns[i].interactable = false;
        }
        Debug.Log(PlayerPrefs.GetInt("Fit0"));
    }

    // �ʱ�ȭ ��ư
    public void ResetBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // ����
        PlayerPrefs.SetInt("sound", 1);
        PlayerPrefs.SetInt("sfx", 1);
    }

    
    // �ð� �߰�
    public void AddDay()
    {
        // ��ư ������ 1�ð� �߰�
        Now = Now + ts;
        Debug.Log(Now);
    }
    // ���� �ð� ��� ��ư
    public void TimeBtn()
    {
        Debug.Log(Now);
    }

    

    // ġƮŰ
    public void CheatBtn()
    {
        // �������� ��� ����
        PlayerPrefs.SetInt("StageClear1", 1);
        PlayerPrefs.SetInt("StageClear2", 1);
        PlayerPrefs.SetInt("StageClear3", 1);
        PlayerPrefs.SetInt("StageClear4", 1);
        PlayerPrefs.SetInt("StageClear5", 1);
        //  �������
        PlayerPrefs.GetInt("StageClearE1", 1);
        PlayerPrefs.GetInt("StageClearE2", 1);
        PlayerPrefs.GetInt("StageClearE3", 1);
        PlayerPrefs.GetInt("StageClearE4", 1);
        PlayerPrefs.GetInt("StageClearE5", 1);
        // ���Ĺ�, ������� 1000 / 100����
        PlayerPrefs.SetInt("Dopamine", 1000);
        PlayerPrefs.SetInt("Serotonin", 100);
        // �ΰ����丮 �ر� ����
        PlayerPrefs.SetInt("Add1", 1);
        PlayerPrefs.SetInt("Add2", 1);
        PlayerPrefs.SetInt("Add3", 1);
        PlayerPrefs.SetInt("Add4", 1);
        PlayerPrefs.SetInt("Add5", 1);
        // ���罺�丮 ���� ����
        PlayerPrefs.SetInt("Hidden1", 1);
        PlayerPrefs.SetInt("Hidden2", 1);
        PlayerPrefs.SetInt("Hidden3", 1);
        PlayerPrefs.SetInt("Hidden4", 1);
        PlayerPrefs.SetInt("Hidden5", 1);
        // ���ν��丮
        PlayerPrefs.SetInt("StoryAt", 6);
        // ��������
        PlayerPrefs.GetInt("levelAt", 6);
        // �� ���ΰ�ħ
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // �⼮üũ
        PlayerPrefs.SetInt("Day1", 0);
        PlayerPrefs.SetInt("Day2", 0);
        PlayerPrefs.SetInt("Day3", 0);
        PlayerPrefs.SetInt("Day4", 0);
        PlayerPrefs.SetInt("Day5", 0);
        PlayerPrefs.SetInt("Day6", 0);
        PlayerPrefs.SetInt("Day7", 0);
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
        // ����
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
        }
        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sfx") == 0)
        {
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);
        }


            // 7���� ��� �޾��� ��
        if ((PlayerPrefs.GetInt("Day1") == 1) && (PlayerPrefs.GetInt("Day2") == 1) && (PlayerPrefs.GetInt("Day3") == 1) && (PlayerPrefs.GetInt("Day4") == 1) && 
            (PlayerPrefs.GetInt("Day5") == 1) && (PlayerPrefs.GetInt("Day6") == 1) && (PlayerPrefs.GetInt("Day7") == 1))
        {
            if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck"))
            {
                PlayerPrefs.SetInt("Day1", 0);
                PlayerPrefs.SetInt("Day2", 0);
                PlayerPrefs.SetInt("Day3", 0);
                PlayerPrefs.SetInt("Day4", 0);
                PlayerPrefs.SetInt("Day5", 0);
                PlayerPrefs.SetInt("Day6", 0);
                PlayerPrefs.SetInt("Day7", 0);
                PlayerPrefs.SetInt("DayCheck", DateTime.Now.Day);
            }
            
        }


        for (int i = 1; i < 7; i++)
        {
            int result = DateTime.Compare(Now, day);

            if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck") || DateTime.Now.Month != PlayerPrefs.GetInt("MonthCheck") && (DayBtns[i-1].interactable==false))
            {
                DayBtns[i].interactable = true;
                PlayerPrefs.SetInt("DayCheck", DateTime.Now.Day);
                PlayerPrefs.SetInt("MonthCheck", DateTime.Now.Month);
                //this.DayBtns[i].GetComponent<Image>().sprite = this.

                for (int j = 0; j < 7; j++)
                {
                    GetBtn[j].SetActive(false);
                    Get2_Btn[j].SetActive(false);
                }
                GetBtn[i + 1].SetActive(true);
                Get2_Btn[i + 1].SetActive(true);
            }
        }
        

        // ����� ��¥�� ���� ��¥�� �ٸ��ٸ�
        if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck") || DateTime.Now.Month!=PlayerPrefs.GetInt("MonthCheck"))
        {
            DayBtns[0].interactable = true;
            PlayerPrefs.SetInt("DayCheck", DateTime.Now.Day);
            PlayerPrefs.SetInt("MonthCheck", DateTime.Now.Month);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    GetBtn[j].SetActive(false);
                    Get2_Btn[j].SetActive(false);
                }
                GetBtn[i+1].SetActive(true);
                Get2_Btn[i+1].SetActive(true);
            }
        }

        // ���ΰ�ħ �� �⼮üũ ȭ�� ����
        if (PlayerPrefs.GetInt("Set") == 1)
        {
            StartCoroutine("Set");
        }

        // �ȵ���̵� back��ư���� ���� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeView.SetActive(true);
        }

        // �⼮üũ �Ϸ� ��ư ���� ����
        for (int i = 0; i < 7; i++)
        {
            int j = i + 1;
            if (PlayerPrefs.GetInt($"Day{j}") == 1)
            {
                DayBtns[i].interactable = false;
                Btnimg[i].SetActive(true);

                GetBTN[i].interactable = false;
                Get2_BTN[i].interactable = false;
                
                /*ColorBlock colorBlock = DayBtns[i].colors;
                colorBlock.normalColor = new Color(1f, 0.8f, 0.4f, 1f);
                colorBlock.highlightedColor = new Color(0.9f, 0.5f, 0.2f, 1f);
                colorBlock.pressedColor = new Color(0.9f, 0.5f, 0.2f, 1f);
                colorBlock.selectedColor = new Color(1f, 0.8f, 0.4f, 1f);
                colorBlock.disabledColor = new Color(1f, 0.8f, 0.4f, 1f);
                DayBtns[i].colors = colorBlock;*/
            }
        }
        for (int i = 0; i < 7; i++)
        {
            int j = i + 1;
            if (PlayerPrefs.GetInt($"Day{j}") == 0)
            {
                Btnimg[i].SetActive(false);
            }
        }

    }

    // ��������
    public void ClickEscapeYes()
    {
        click.Play();
        Application.Quit();
    }
    public void ClickEscapeNo()
    {
        click.Play();
        EscapeView.SetActive(false);
    }

    // ���ӽ��� ��ư
    public void ClickStart()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Play", 0) == 0)
        {
            PlayerPrefs.SetInt("Play", 1);
            SceneManager.LoadScene(8);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(11);
            Time.timeScale = 1;
        }
    }

    // ���� ��ư
    public void ClickStore()
    {
        click.Play();
        SceneManager.LoadScene(9);
    }

    // ���丮 ��ư
    public void ClickStory()
    {
        click.Play();
        SceneManager.LoadScene(7);
    }

    // ���� â ����
    public void ClickSetting()
    {
        click.Play();
        SettingView.SetActive(true);
    }

    // ���� â �ݱ�
    public void ClickSettingClose()
    {
        click.Play();
        SettingView.SetActive(false);
    }

    // ���� �Ű� â ����
    public void ClickHelp()
    {
        click.Play();
        HelpView.SetActive(true);
    }

    // ���� �Ű� â �ݱ�
    public void ClickHelpClose()
    {
        click.Play();
        HelpView.SetActive(false);
    }

    public void Count()
    {
        Dopamine.text = D.ToString();
        Serotonin.text = S.ToString();
    }

    // Ȩȭ�鿡�� �⼮üũ ��ư
    public void DayBtn()
    {
        click.Play();
        DayView.SetActive(true);
    }

    // �⼮üũ �� �ݱ� ��ư
    public void DayCloseBtn()
    {
        click.Play();
        DayView.SetActive(false);
    }

    // day��ư
    public void DayBtn1()
    {
        click.Play();
        Views1.SetActive(true);
    }

    // Views �ݱ� ��ư
    public void ViewsCloseBtn1()
    {
        click.Play();
        Views1.SetActive(false);
    }

    public void DayBtn2()
    {
        click.Play();
        Views2.SetActive(true);
    }
    public void ViewsCloseBtn2()
    {
        click.Play();
        Views2.SetActive(false);
    }

    public void DayBtn3()
    {
        click.Play();
        Views3.SetActive(true);
    }
    public void ViewsCloseBtn3()
    {
        click.Play();
        Views3.SetActive(false);
    }

    public void DayBtn4()
    {
        click.Play();
        Views4.SetActive(true);
    }
    public void ViewsCloseBtn4()
    {
        click.Play();
        Views4.SetActive(false);
    }

    public void DayBtn5()
    {
        click.Play();
        Views5.SetActive(true);
    }
    public void ViewsCloseBtn5()
    {
        click.Play();
        Views5.SetActive(false);
    }

    public void DayBtn6()
    {
        click.Play();
        Views6.SetActive(true);
    }
    public void ViewsCloseBtn6()
    {
        Views6.SetActive(false);
        click.Play();
    }

    public void DayBtn7()
    {
        Views7.SetActive(true);
        click.Play();
    }
    public void ViewsCloseBtn7()
    {
        Views7.SetActive(false);
        click.Play();
    }

    // �⼮��ũ �� �����ϱ�(���ΰ�ħ ��)
    IEnumerator Set()
    {
        yield return new WaitForSeconds(0.000001f);
        DayView.SetActive(true);
        PlayerPrefs.SetInt("Set", 0);
    }

    // �⼮üũ ������� ���� �ޱ�
    public void GetBtn1()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        Views1.SetActive(false);
        GetBTN[0].interactable = false;
        Get2_BTN[0].interactable = false;
        PlayerPrefs.SetInt("Day1", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Set", 1);
    }

    public void GetBtn2()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        Views2.SetActive(false);
        GetBTN[1].interactable = false;
        Get2_BTN[1].interactable = false;
        PlayerPrefs.SetInt("Day2", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Set", 1);
    }

    public void GetBtn3()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 100);
        Views3.SetActive(false);
        GetBTN[2].interactable = false;
        Get2_BTN[2].interactable = false;
        PlayerPrefs.SetInt("Day3", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        PlayerPrefs.SetInt("Set", 1);
    }

    public void GetBtn4()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        Views4.SetActive(false);
        GetBTN[3].interactable = false;
        Get2_BTN[3].interactable = false;
        PlayerPrefs.SetInt("Day4", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Set", 1);
    }

    public void GetBtn5()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        Views5.SetActive(false);
        GetBTN[4].interactable = false;
        Get2_BTN[4].interactable = false;
        PlayerPrefs.SetInt("Day5", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Set", 1);
    }

    public void GetBtn6()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 150);
        Views6.SetActive(false);
        GetBTN[5].interactable = false;
        Get2_BTN[5].interactable = false;
        PlayerPrefs.SetInt("Day6", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Set", 1);
    }

    public void GetBtn7()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 500);
        Views7.SetActive(false);
        GetBTN[6].interactable = false;
        Get2_BTN[6].interactable = false;
        PlayerPrefs.SetInt("Day7", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Set", 1);
    }

    // ����
    public void SoundOFF()
    {
        PlayerPrefs.SetInt("sound", 0);
        soundOff.SetActive(false);
        soundOn.SetActive(true);
        click.Play();
    }
    public void SoundON()
    {
        PlayerPrefs.SetInt("sound", 1);
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        click.Play();
    }

    public void SfxOFF()
    {
        PlayerPrefs.SetInt("sfx", 0);
        sfxOff.SetActive(false);
        sfxOn.SetActive(true);
        click.Play();
    }
    public void SfxON()
    {
        PlayerPrefs.SetInt("sfx", 1);
        sfxOff.SetActive(true);
        sfxOn.SetActive(false);
        click.Play();
    }

    public void ShakeOFF()
    {
        PlayerPrefs.SetInt("shake", 0);
        shakeOff.SetActive(false);
        shakeOn.SetActive(true);
        click.Play();
    }
    public void ShakeON()
    {
        PlayerPrefs.SetInt("shake", 1);
        shakeOff.SetActive(true);
        shakeOn.SetActive(false);
        click.Play();
    }

    // �⼮üũ �ޱ� ��ư Ȱ��ȭ
    public void SetBtn1()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[i].SetActive(false);
            Get2_Btn[i].SetActive(false);
        }
        GetBtn[0].SetActive(true);
        Get2_Btn[0].SetActive(true);
    }
    public void SetBtn2()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[i].SetActive(false);
            Get2_Btn[i].SetActive(false);
        }
        GetBtn[1].SetActive(true);
        Get2_Btn[1].SetActive(true);
    }
    public void SetBtn3()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[2].SetActive(false);
            Get2_Btn[2].SetActive(false);
        }
        GetBtn[0].SetActive(true);
        Get2_Btn[0].SetActive(true);
    }
    public void SetBtn4()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[i].SetActive(false);
            Get2_Btn[i].SetActive(false);
        }
        GetBtn[3].SetActive(true);
        Get2_Btn[3].SetActive(true);
    }
    public void SetBtn5()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[i].SetActive(false);
            Get2_Btn[i].SetActive(false);
        }
        GetBtn[4].SetActive(true);
        Get2_Btn[4].SetActive(true);
    }
    public void SetBtn6()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[i].SetActive(false);
            Get2_Btn[i].SetActive(false);
        }
        GetBtn[5].SetActive(true);
        Get2_Btn[5].SetActive(true);
    }
    public void SetBtn7()
    {
        for (int i = 0; i < 7; i++)
        {
            GetBtn[i].SetActive(false);
            Get2_Btn[i].SetActive(false);
        }
        GetBtn[6].SetActive(true);
        Get2_Btn[6].SetActive(true);
    }
}