using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStage3 : MonoBehaviour
{
    // 3�������� ���� : ����� ���� OR ���� ? ���� �� OR ���� �Ʒ�        ?    ���� �� OR ���� �Ʒ�     ?     ���� �� OR ���� �Ʒ�    ? ����� ���� OR ����

    // �⺻ ����
    [SerializeField]
    GameObject Destination, DeadZone;

    // map1zone : ����� 1 ����[0], ���� ����[1]     map2zone : ���� ��[1] / �Ʒ� [0]    
    [SerializeField]
    GameObject[] map1zone, map2zone;

    int r1, r2, r5;

    // y�� ����
    [HideInInspector]
    public float a1, a2, b1, b2, c;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        // 1����   ����� ����[0] / ����[1]
        r1 = Random.Range(0, 2);
        switch (r1)
        {
            // 0 : �����  1 : ����
            case 0:
                Instantiate(map1zone[0], new Vector3(0, 0, 0), Quaternion.identity);
                //a1 = -19f; //b1 = -55f;
                break;
            case 1:
                Instantiate(map1zone[1], new Vector3(0, 0, 0), Quaternion.identity);
                //a2 = 19f; //b2 = -16f;
                break;
        }

        // 2���� 
        r2 = Random.Range(0, 2);
        switch (r2)
        {
            // 0 : �ٿ�  1 : ��
            case 0:
                Instantiate(map2zone[0], new Vector3(100, -35, 0), Quaternion.identity);
                a1 = -19f; //b1 = -55f;

                // 3���� ��
                Instantiate(map2zone[1], new Vector3(160, -35, 0), Quaternion.identity); //

                // 4���� �ٿ� 
                Instantiate(map2zone[0], new Vector3(220, -35, 0), Quaternion.identity); //
                r5 = Random.Range(0, 2);
                switch (r5) // 5���� ����
                {
                    case 0:
                        Instantiate(map1zone[0], new Vector3(240, -19, 0), Quaternion.identity);
                        Instantiate(Destination, new Vector3(302, -30, 0), Quaternion.identity);
                        Instantiate(DeadZone, new Vector3(348, -36, 3.529f), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(map1zone[1], new Vector3(240, -19, 0), Quaternion.identity);
                        Instantiate(Destination, new Vector3(302, -28, 0), Quaternion.identity);
                        Instantiate(DeadZone, new Vector3(348, -36, 3.529f), Quaternion.identity);
                        break;
                }
                break;


            case 1:
                Instantiate(map2zone[1], new Vector3(100, -17, 0), Quaternion.identity);
                a2 = 19f; //b2 = -16f;

                // 3���� �ٿ�
                Instantiate(map2zone[0], new Vector3(160, -17, 0), Quaternion.identity);

                // 4���� ��
                Instantiate(map2zone[1], new Vector3(220, -17, 0), Quaternion.identity);
                r5 = Random.Range(0, 2);
                switch (r5) // 5���� ����
                {
                    case 0:
                        Instantiate(map1zone[0], new Vector3(240, 19, 0), Quaternion.identity);
                        Instantiate(Destination, new Vector3(302, 8, 0), Quaternion.identity);
                        Instantiate(DeadZone, new Vector3(348, 2, 3.529f), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(map1zone[1], new Vector3(240, 19, 0), Quaternion.identity);
                        Instantiate(Destination, new Vector3(302, 10, 0), Quaternion.identity);
                        Instantiate(DeadZone, new Vector3(348, 2, 3.529f), Quaternion.identity);
                        break;
                }
                break;
        }
    }
}