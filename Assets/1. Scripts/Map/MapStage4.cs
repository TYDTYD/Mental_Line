using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStage4 : MonoBehaviour
{
    // 4�������� ���� : ����� ���� OR ���� ? ���� �� OR ���� �Ʒ�        ? ����� �� OR ����� �Ʒ� ? ���� �� OR ���� �Ʒ� ? ����� ���� OR ����


    // �⺻ ����
    [SerializeField]
    GameObject Destination, DeadZone;

    // map1zone : ����� 1 ����[0], ���� ����[1]     map2zone : ���� ��[1] / �Ʒ� [0]     map3zone : ����� ��[1] / �Ʒ�[0]
    [SerializeField]
    GameObject[] map1zone, map2zone, map3zone;

    int r1, r2, r3, r4, r5;

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
                break;
            case 1:
                Instantiate(map2zone[1], new Vector3(100, -17, 0), Quaternion.identity);
                a2 = 19f; //b2 = -16f;
                break;
        }

        // 3����
        r3 = Random.Range(0, 2);
        if (r2 == 0)
        {
            switch (r3)
            {
                // 0 : �ٿ�  1 : ��
                case 0:
                    Instantiate(map3zone[0], new Vector3(160, -55, 0), Quaternion.identity); 
                    break;
                case 1:
                    Instantiate(map3zone[1], new Vector3(160, -35, 0), Quaternion.identity); 
                    break;
            }
        }
        else if (r2 == 1)
        {
            b2 = -16f;
            switch (r3)
            {
                // 0 : �ٿ�  1 : ��
                case 0: // �ٿ�
                    Instantiate(map3zone[0], new Vector3(160, -17, 0), Quaternion.identity); 
                    break;
                case 1: // ��
                    Instantiate(map3zone[1], new Vector3(160, 3, 0), Quaternion.identity); 
                    break;
            }
        }

        // 4����  5����
        r4 = Random.Range(0, 2);
        r5 = Random.Range(0, 2);
        if (r2 == 0 && r3 == 0)
        {
            switch (r4)
            {
                // 0 : �ٿ�  1 : ��
                case 0:
                    Instantiate(map2zone[0], new Vector3(220, -75, 0), Quaternion.identity); 
                    switch (r5) 
                    {
                        case 0:
                            Instantiate(map1zone[0], new Vector3(240, -60, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, -71, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, -77, 3.529f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(map1zone[1], new Vector3(240, -60, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, -69, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, -77, 3.529f), Quaternion.identity);
                            break;
                    }
                    break;
                case 1:
                    Instantiate(map2zone[1], new Vector3(220, -55, 0), Quaternion.identity); 
                    switch (r5) 
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
            }
        }
        else if (r2 == 1 && r3 == 1)
        {
            b2 = -16f;
            switch (r4)
            {
                // 0 : �ٿ�  1 : ��
                case 0:
                    Instantiate(map2zone[0], new Vector3(220, 3, 0), Quaternion.identity); 
                    switch (r5) 
                    {
                        case 0:
                            Instantiate(map1zone[0], new Vector3(240, 17, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, 6, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, 0, 3.529f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(map1zone[1], new Vector3(240, 17, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, 8, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, 0, 3.529f), Quaternion.identity);
                            break;
                    }
                    break;
                case 1:
                    Instantiate(map2zone[1], new Vector3(220, 23, 0), Quaternion.identity);  
                    switch (r5) 
                    {
                        case 0:
                            Instantiate(map1zone[0], new Vector3(240, 58, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, 39, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, 33, 3.529f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(map1zone[1], new Vector3(240, 58, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, 50, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, 40, 3.529f), Quaternion.identity);
                            break;
                    }
                    break;
            }
        }
        else if (r2 == 0 && r3 == 1)
        {
            switch (r4)
            {
                // 0 : �ٿ�  1 : ��
                case 0:
                    Instantiate(map2zone[0], new Vector3(220, -35, 0), Quaternion.identity); 
                    switch (r5) 
                    {
                        case 0:
                            Instantiate(map1zone[0], new Vector3(240, -19, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, -30, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, -36, 3.529f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(map1zone[1], new Vector3(240, -19, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, -30, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, -36, 3.529f), Quaternion.identity);
                            break;
                    }
                    break;
                case 1:
                    Instantiate(map2zone[1], new Vector3(220, -15, 0), Quaternion.identity);  
                    switch (r5) 
                    {
                        case 0:
                            Instantiate(map1zone[0], new Vector3(240, 21, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, 10, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, 4, 3.529f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(map1zone[1], new Vector3(240, 21, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, 12, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, 4, 3.529f), Quaternion.identity);
                            break;
                    }
                    break;
            }
        }
        else if (r2 == 1 && r3 == 0)
        {
            switch (r4)
            {
                // 0 : �ٿ�  1 : ��
                case 0:
                    Instantiate(map2zone[0], new Vector3(220, -37, 0), Quaternion.identity);
                    switch (r5) 
                    {
                        case 0:
                            Instantiate(map1zone[0], new Vector3(240, -22, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, -33, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, -39, 3.529f), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(map1zone[1], new Vector3(240, -22, 0), Quaternion.identity);
                            Instantiate(Destination, new Vector3(302, -31, 0), Quaternion.identity);
                            Instantiate(DeadZone, new Vector3(348, -39, 3.529f), Quaternion.identity);
                            break;
                    }
                    break;
                case 1: 
                    Instantiate(map2zone[1], new Vector3(220, -17, 0), Quaternion.identity);
                    switch (r5)
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
}