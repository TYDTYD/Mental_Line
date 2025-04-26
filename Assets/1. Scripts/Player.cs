using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject startBlock;
    string log;

    private float Speed = 6.5f;
    private SpringJoint spring;
    private Grappling grappling;
    private Rigidbody rig;
    private int start;
    private int index;
    private int indexE;
    private int dopamine;
    private int serotonin;
    private GameObject hook;

    // 사운드
    public AudioSource dead;
    public AudioSource clear;
    public AudioSource[] BGM;
    public AudioSource Mon;
    public AudioSource com;

    // 애니메이터
    private Animator PlayerAnimator;

    // 최고 점수 텍스트
    private int BestScore;
    private int BestScoreE;

    // 성공했을때 점수 텍스트
    public Text SuccessScore;

    // 점수
    public int targetScore;

    // 죽었을 때
    public GameObject DeadView;
    
    // 도착지
    public GameObject FirstDestinationView;
    public GameObject DestinaionView;
    public Text TotalScore;
    [HideInInspector]
    public bool Clear;

    // 도파민, 세로토민
    public Text Dopamine;
    public Text Dopamine2;
    public Text Serotonin;
    public Text Serotonin2;
    public int scoreSum=0;
    private int itemCount;
    private int itemCount2;

    // 몬스터 경고
    public GameObject Warning;

    // 콤보
    private int ComboCount;
    public GameObject ComboView;

    // 이펙트
    public ParticleSystem particle;

    // 시작 후 카운트 3, 2, 1
    public Text TimeCount;
    public Text ClearText;
    public Grappling gp;
    public GameObject img;

    // 별점 개수UI
    public GameObject[] Stars;

    List<GameObject> DeletedObjects = new List<GameObject>();

    private void Awake()
    {
        index = PlayerPrefs.GetInt("StageClear" + (SceneManager.GetActiveScene().buildIndex - 1));
        indexE = PlayerPrefs.GetInt("StageClearE" + (SceneManager.GetActiveScene().buildIndex - 12));
        start = PlayerPrefs.GetInt("Play");
        dopamine = PlayerPrefs.GetInt("Dopamine");
        serotonin = PlayerPrefs.GetInt("Serotonin");
        BestScore = PlayerPrefs.GetInt("BestScore" + (SceneManager.GetActiveScene().buildIndex - 1));
        BestScoreE = PlayerPrefs.GetInt("BestScoreE" + (SceneManager.GetActiveScene().buildIndex - 12));
    }

    // Start is called before the first frame update
    void Start()
    {
        hook = GameObject.FindWithTag("Hook");
        rig = GetComponent<Rigidbody>();
        grappling = hook.GetComponent<Grappling>();
        PlayerPrefs.SetInt("Play", start + 1);
        rig.velocity = new Vector3(0, 0);
        PlayerAnimator = GetComponent<Animator>();
        //BGM.Play();

        // BGM 변경
        for (int i = 0; i < 18; i++)
        {
            if (PlayerPrefs.GetInt($"Fit{i}") == 1)
            {
                BGM[i].Play();
            }
        }
        StartCoroutine(BeforeStart());
    }

    // Update is called once per frame
    void Update()
    {

        // 몬스터 충돌 시 이펙트 효과 (플레이어의 위치에서 콤보 효과 발생)
        particle.transform.position = transform.position; // + new Vector3(2,1,0);

        if (grappling.IsGrappling() && gp.isPlay == true)
        {
            PlayerAnimator.SetTrigger("Fly");

        }
        if (!Input.GetMouseButton(0))
        {
            spring = gameObject.GetComponent<SpringJoint>();
            if (spring != null)
            {
                Destroy(spring);
            }
        }
        else
        {
            if (transform.position.y > grappling.GetGrapplePoint().y)
            {
                transform.LookAt(new Vector3(transform.position.x - 1, ((grappling.GetGrapplePoint().x - transform.position.x) / (grappling.GetGrapplePoint().y - transform.position.y)) + transform.position.y));
            }
            else
            {
                transform.LookAt(new Vector3(transform.position.x + 1, ((transform.position.x - grappling.GetGrapplePoint().x) / (grappling.GetGrapplePoint().y - transform.position.y)) + transform.position.y));
            }
        }
    }
    private void FixedUpdate()
    {
        // 속도 제한 값 계산
        float xClamp = Mathf.Clamp(rig.velocity.x, -Speed, Speed);
        float yClamp = Mathf.Clamp(rig.velocity.y, -Speed, Speed);

        // 제한 값 적용
        rig.velocity = new Vector3(xClamp, yClamp);

        if (grappling.IsGrappling())
        {
            rig.AddForce(transform.forward * 12.5f);
        }
    }

    // 전면 광고 - Dead
    public Canvas myCan;

    private void OnTriggerEnter(Collider collision)
    {

        switch (collision.gameObject.tag)
        {   
            // 도파민
            case "item":
                itemCount++;
                ComboCount++;
                Combo();
                Item_();
                Num();
                collision.gameObject.SetActive(false);
                DeletedObjects.Add(collision.gameObject);
                break;

            case "ItemB":
                itemCount2++;
                Item_2();
                collision.gameObject.SetActive(false);
                DeletedObjects.Add(collision.gameObject);
                break;

            case "Ring":
            case "Wall":
                dead.Play();
                Dead();
                break;
            case "Finish":
                if (scoreSum>= targetScore)
                {
                    for (int i = 0; i < BGM.Length; i++)
                    {
                        BGM[i].Stop();
                    }

                    if (scoreSum >= 3000)
                    {
                        Stars[2].SetActive(true);
                    }
                    else if (scoreSum >= 2500)
                    {
                        Stars[1].SetActive(true);
                    }
                    else if (scoreSum >= 2000)
                    {
                        Stars[0].SetActive(true);
                    }

                    clear.Play();
                    if (scoreSum > BestScore)
                    {
                        PlayerPrefs.SetInt("BestScore"+ (SceneManager.GetActiveScene().buildIndex - 1), scoreSum);
                        if (SceneManager.GetActiveScene().buildIndex == 2)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_1, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex==3)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_2, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex==4)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_3, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex==5)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_4, scoreSum, success => log = $"{success}");
                        }
                        else
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_5, scoreSum, success => log = $"{success}");
                        }
                        
                    }

                    Destination();
                    break;
                }
                else
                {
                    dead.Play();
                    Dead();
                    break;
                }
                //이지모드
            case "FinishEasy":
                if (scoreSum>= targetScore)
                {
                    for (int i = 0; i < BGM.Length; i++)
                    {
                        BGM[i].Stop();
                    }

                    if (scoreSum >= 2700)
                    {
                        Stars[2].SetActive(true);
                    }
                    else if (scoreSum >= 2200)
                    {
                        Stars[1].SetActive(true);
                    }
                    else if (scoreSum >= 1700)
                    {
                        Stars[0].SetActive(true);
                    }

                    clear.Play();
                    if (scoreSum > BestScoreE)
                    {
                        PlayerPrefs.SetInt("BestScoreE"+ (SceneManager.GetActiveScene().buildIndex - 12), scoreSum);
                        if (SceneManager.GetActiveScene().buildIndex == 13)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_1, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 14)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_2, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 15)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_3, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 16)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_4, scoreSum, success => log = $"{success}");
                        }
                        else
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_5, scoreSum, success => log = $"{success}");
                        }
                    }
                    
                    DestinationEasy();
                    break;
                }
                else
                {
                    dead.Play();
                    Dead();
                    break;
                }

            case "Monster":
                dead.Play();
                playpar();
                Dead();
                break;

            case "Move":
            case "MoveUp":
            case "MoveDown":
            case "MoveDownStage3":
            case "MoveUpStage3":
            case "MoveStage5":
                Mon.Play();   
                
                playpar();

                // 도파민 차감
                itemCount = itemCount - (itemCount / 10);
                Item_();

                // 스코어 점수 차감
                if (scoreSum == 0)
                {
                    scoreSum = 0;
                }
                else if (scoreSum >= 1 && scoreSum <= 50)
                {
                    scoreSum = 0;
                }
                else if (scoreSum > 50)
                {
                    scoreSum -= 50;
                }
                break;

            case "Trigger":
                StartCoroutine("Time_");
                break;

                // 콤보
            case "Combo":
                ComboCount = 0;
                break;

                // 튜토리얼 2구역
            case "Guide2":
                //
                break;
        }
    }

    public void Combo()
    {
        // 도파민을 5번 먹으면 콤보 효과가 발생하도록
        for (int i=1; i<50; i++)
        {
            if (ComboCount == i*5)
            {
                com.Play();
                scoreSum = scoreSum + 20 + i * 10;
                ComboView.GetComponent<Text>().text = i + " Combo!";
                StartCoroutine("Time1");
            }
        }
    }

    // 콤보 시 이펙트 효과
    public void playpar()
    {
        particle.Play();
    }

    IEnumerator Time_()
    {
        Warning.SetActive(true);

        // 최적화 관련 코루틴 코드
        yield return YieldInstructionCache.WaitForSeconds(1);
        //yield return new WaitForSecondsRealtime(1);
        Warning.SetActive(false);
    }

    IEnumerator Time1()
    {
        ComboView.SetActive(true);

        // 최적화 관련 코루틴 코드
        yield return YieldInstructionCache.WaitForSeconds(1);
        ComboView.SetActive(false);
    }

    void Dead()
    {
        // 게임 실패
        Clear = false;

        // 시간 멈춤
        Time.timeScale = 0;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("DDopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);

        DeadView.SetActive(true);
        hook.SetActive(false);
    }
    public void Destination()
    {
        // 게임 성공
        Clear = true;
        Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("DDopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);
        PlayerPrefs.SetInt("StageClear" + (SceneManager.GetActiveScene().buildIndex - 1), index + 1);
       
        DestinaionView.SetActive(true);
        hook.SetActive(false);
    }
    // 이지모드
    public void DestinationEasy()
    {
        // 게임 성공
        Clear = true;
        Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("DDopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);

        PlayerPrefs.SetInt("StageClearE" + (SceneManager.GetActiveScene().buildIndex - 12), index + 1);

        // 첫 클리어 시 해금 문구 발생
        if (indexE == 0 && SceneManager.GetActiveScene().buildIndex != 10)
        {
            FirstDestinationView.SetActive(true);
        }
        else
        {
            DestinaionView.SetActive(true);
        }
        hook.SetActive(false);
    }
    public void Num()
    {
        scoreSum += 10;
        TotalScore.text = scoreSum.ToString();
    }
    // 도파민
    public void Item_()
    {
        // 화면에 텍스트 출력
        Dopamine.text = itemCount.ToString();
        Dopamine2.text = itemCount.ToString();
    }
    public void Item_2()
    {
        // 화면에 텍스트 출력
        Serotonin.text = itemCount2.ToString();
        Serotonin2.text = itemCount2.ToString();
    }
    // 게임 시작 전 카운트
    IEnumerator BeforeStart()
    {
        yield return new WaitForSeconds(1);
        TimeCount.text = "2";
        yield return new WaitForSeconds(1);
        TimeCount.text = "1";
        yield return new WaitForSeconds(1);
        TimeCount.gameObject.SetActive(false);
        ClearText.gameObject.SetActive(false);
        img.gameObject.SetActive(false);

        gp.isPlay = true;
    }
    void ReviveObj()
    {
        foreach(var obj in DeletedObjects)
        {
            obj.SetActive(true);
        }
        DeletedObjects.Clear();
    }
    public void Restart()
    {
        ReviveObj();
        itemCount = 0;
        itemCount2 = 0;
        scoreSum = 0;
        Item_();
        Item_2();
        TotalScore.text = scoreSum.ToString();
        transform.rotation = Quaternion.Euler(new Vector3(0, 90));
        transform.position = startBlock.transform.position + new Vector3(0, 1);
        rig.velocity = new Vector3(0, 0);
        startBlock.SetActive(true);
        hook.SetActive(true);
        gameObject.SetActive(true);
        DeadView.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(BeforeStart());
    }
}