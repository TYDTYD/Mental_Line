using UnityEngine;

public class MapStage1 : MonoBehaviour
{
    // �⺻ ����
    [SerializeField]
    GameObject map1zone, Destination, DeadZone;
    // ���� �� �Ʒ� [0] : �Ʒ�  / [1] : ��
    [SerializeField]
    GameObject[] map2zone;
    int r1, r2, r3;
    // y�� ����
    [HideInInspector]
    public float a1, a2, b1, b2, c;
    void Start() => Spawn();

    void Spawn()
    {
        // 1����
        Instantiate(map1zone, new Vector3(0, 0, 0), Quaternion.identity);

        // 2���� : ���� �� / �Ʒ�
        r1 = Random.Range(0, 2);
        switch (r1)
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

        // 3���� : �⺻ ����
        if (r1 == 0)
        {
            switch (r2)
            {
                case 0:
                    Instantiate(map1zone, new Vector3(120, a1, 0), Quaternion.identity);
                    break;
            }
        }
        else if (r1 == 1)
        {
            b2 = -16f;
            switch (r2)
            {
                case 0:
                    Instantiate(map1zone, new Vector3(120, a2, 0), Quaternion.identity);
                    break;
            }
        }

        // 4���� : ���� �� / �Ʒ�
        r3 = Random.Range(0, 2);
        if (r1 == 0)
        {
            // b1 = -33f;
            switch (r3)
            {
                case 0:
                    Instantiate(map2zone[0], new Vector3(220, -55, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(map2zone[1], new Vector3(220, -35, 0), Quaternion.identity);
                    break;
            }
        }
        else if(r1 == 1)
        {
            b2 = -16f;
            switch(r3)
            {
                case 0:
                    Instantiate(map2zone[0], new Vector3(220, b2, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(map2zone[1], new Vector3(220, 2, 0), Quaternion.identity);
                    break;
            }
            
        }

        // 5���� : �⺻ ����
        if (r1 == 0 && r3 == 0)
        {
            Instantiate(map1zone, new Vector3(240, -39, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, -49, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, -55, 3.529f), Quaternion.identity);
        }
        else if (r1 == 0 && r3 == 1)
        {
            Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, -9, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, -17, 3.529f), Quaternion.identity);
        }
        else if (r1 == 1 && r3 == 0)
        {
            Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, -9, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, -17, 3.529f), Quaternion.identity);
        }
        else if (r1 == 1 && r3 == 1)
        {
            Instantiate(map1zone, new Vector3(240, 37.5f, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, 27, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, 21, 3.529f), Quaternion.identity);
        }
    }
}