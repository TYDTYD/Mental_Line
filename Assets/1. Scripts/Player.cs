using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject startBlock;

    private float Speed=6.5f;
    private SpringJoint spring;
    private Grappling grappling;
    private Rigidbody rig;
    private int start;
    private int index;
    private int indexE;
    private int dopamine;
    private int serotonin;
    private GameObject hook;

    // ����
    public AudioSource dead;
    public AudioSource clear;
    public AudioSource[] BGM;
    public AudioSource Mon;

    // �ִϸ�����
    private Animator PlayerAnimator;

    // �ְ� ���� �ؽ�Ʈ
    private int BestScore;
    private int BestScoreE;

    // ���������� ���� �ؽ�Ʈ
    public Text SuccessScore;

    // ����
    public int targetScore;

    // �׾��� ��
    public GameObject DeadView;
    
    // ������
    public GameObject FirstDestinationView;
    public GameObject DestinaionView;
    public Text TotalScore;
    [HideInInspector]
    public bool Clear;

    // ���Ĺ�, �������
    public Text Dopamine;
    public Text Serotonin;
    public int scoreSum=0;
    private int itemCount;
    private int itemCount2;

    

    // ���� ���
    public GameObject Warning;

    // �޺�
    private int ComboCount;
    public GameObject ComboView;

    // ����Ʈ
    public ParticleSystem particle;

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

        // BGM ����
        for (int i = 0; i < 18; i++)
        {
            if (PlayerPrefs.GetInt($"Fit{i}") == 1)
            {
                BGM[i].Play();
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        // ���� �浹 �� ����Ʈ ȿ�� (�÷��̾��� ��ġ���� �޺� ȿ�� �߻�)
        particle.transform.position = transform.position; // + new Vector3(2,1,0);

        if (grappling.IsGrappling())
        {
            PlayerAnimator.SetTrigger("Fly");
            
        }
        if(!Input.GetMouseButton(0))
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
        // �ӵ� ���� �� ���
        float xClamp = Mathf.Clamp(rig.velocity.x, -Speed, Speed);
        float yClamp = Mathf.Clamp(rig.velocity.y, -Speed, Speed);

        // ���� �� ����
        rig.velocity = new Vector3(xClamp, yClamp);

        if (grappling.IsGrappling())
        {
            rig.AddForce(transform.forward * 12.5f);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        switch (collision.gameObject.tag)
        {
            
            // ���Ĺ�
            case "item":
                itemCount++;
                ComboCount++;
                Combo();

                Item_();
                Num();
                collision.gameObject.SetActive(false);
                break;

            case "ItemB":
                itemCount2++;
                Item_2();
                collision.gameObject.SetActive(false);
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
                    
                    clear.Play();
                    if (scoreSum > BestScore)
                    {
                        PlayerPrefs.SetInt("BestScore"+ (SceneManager.GetActiveScene().buildIndex - 1), scoreSum);
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
                //�������
            case "FinishEasy":
                if (scoreSum>= targetScore)
                {
                    for (int i = 0; i < BGM.Length; i++)
                    {
                        BGM[i].Stop();
                    }

                    clear.Play();
                    if (scoreSum > BestScoreE)
                    {
                        PlayerPrefs.SetInt("BestScoreE"+ (SceneManager.GetActiveScene().buildIndex - 12), scoreSum);
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

                // ���Ĺ� ����
                itemCount = itemCount - (itemCount / 10);
                Item_();

                // ���ھ� ���� ����
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
                StartCoroutine("Time");
                break;

                // �޺�
            case "Combo":
                ComboCount = 0;
                break;

                // Ʃ�丮�� 2����
            case "Guide2":
                //
                break;
        }
    }

    public void Combo()
    {
        // ���Ĺ��� 5�� ������ �޺� ȿ���� �߻��ϵ���
        for (int i=1; i<50; i++)
        {
            if (ComboCount == i*5)
            {
                scoreSum = scoreSum + 20 + i * 10;
                ComboView.GetComponent<Text>().text = i + " Combo!";
                StartCoroutine("Time1");
            }
        }
       
    }

    // �޺� �� ����Ʈ ȿ��
    public void playpar()
    {
        particle.Play();
    }

    IEnumerator Time()
    {
        Warning.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        Warning.SetActive(false);
    }

    IEnumerator Time1()
    {
        ComboView.SetActive(true);
        yield return new WaitForSeconds(1);
        ComboView.SetActive(false);
    }

    void Dead()
    {
        // ���� ����
        Clear = false;

        // �ð� ����
        UnityEngine.Time.timeScale = 0;

        PlayerPrefs.SetInt("Dopamine", dopamine+itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin+itemCount2);
        DeadView.SetActive(true);
        hook.SetActive(false);
    }

    public void Destination()
    {
        // ���� ����
        Clear = true;
        UnityEngine.Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);
        // ù Ŭ���� �� �ر� ���� �߻�
        if (index==0 && SceneManager.GetActiveScene().buildIndex!=10)
        {
            FirstDestinationView.SetActive(true);
        }
        else
        {
            DestinaionView.SetActive(true);
        }
        PlayerPrefs.SetInt("StageClear" + (SceneManager.GetActiveScene().buildIndex - 1), index + 1);
        hook.SetActive(false);
    }
    // �������
    public void DestinationEasy()
    {
        // ���� ����
        Clear = true;
        UnityEngine.Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);
        // ù Ŭ���� �� �ر� ���� �߻�
        if (indexE == 0 && SceneManager.GetActiveScene().buildIndex != 10)
        {
            FirstDestinationView.SetActive(true);
        }
        else
        {
            DestinaionView.SetActive(true);
        }
        PlayerPrefs.SetInt("StageClearE" + (SceneManager.GetActiveScene().buildIndex - 12), index + 1);
        hook.SetActive(false);
    }


    public void Num()
    {
        string b = " / "+targetScore.ToString();
        scoreSum += 10;
        TotalScore.text = scoreSum.ToString();
    }

    

    // ���Ĺ�
    public void Item_()
    {
        // ȭ�鿡 �ؽ�Ʈ ���
        Dopamine.text = itemCount.ToString();
    }

    public void Item_2()
    {
        // ȭ�鿡 �ؽ�Ʈ ���
        Serotonin.text = itemCount2.ToString();
    }
}