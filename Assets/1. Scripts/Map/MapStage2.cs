using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStage2 : MonoBehaviour
{
    // 기본 평평
    [SerializeField]
    GameObject map1zone, Destination, DeadZone;

    // map2zone : 쉬운 위[1] / 아래 [0]    map3zone : 어려움 1 평평[0], 물결 평평[1]
    [SerializeField]
    GameObject[] map2zone, map3zone;

    // 기본 평평         ? 쉬운 위 OR 쉬운 아래        ?     어려운 평평 OR 물결     ?     쉬운 위 OR 쉬운 아래    ?           기본 평평

    int r1, r2, r3;

    // y값 변수
    [HideInInspector]
    public float a1, a2, b1, b2, c;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        // 1구간
        Instantiate(map1zone, new Vector3(0,0,0), Quaternion.identity);

        // 2구간
        r1 = Random.Range(0, 2);
        switch(r1)
        {
            // 0 : 다운  1 : 업
            case 0:
                Instantiate(map2zone[0], new Vector3(100,-35,0), Quaternion.identity);
                a1 = -19f; //b1 = -55f;
                break;
            case 1:
                Instantiate(map2zone[1], new Vector3(100,-17,0), Quaternion.identity);
                a2 = 19f; //b2 = -16f;
                break;
        }

        // 3구간
        r2 = Random.Range(0, 2);
        if(r1 == 0)
        {
            switch (r2)
            {
                // 0 : 어려움1  1 : 물결
                case 0:
                    Instantiate(map3zone[0], new Vector3(120, a1, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(map3zone[1], new Vector3(120, a1, 0), Quaternion.identity);
                    break;
            }
        }
        else if(r1 == 1)
        {
            b2 = -16f;
            switch (r2)
            {
                // 0 : 어려움1  1 : 물결
                case 0:
                    Instantiate(map3zone[0], new Vector3(120, a2, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(map3zone[1], new Vector3(120, a2, 0), Quaternion.identity);
                    break;
            }
        }
        

        // 4구간
        r3 = Random.Range(0, 2);

        if(r1 == 0)
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
        

        // 5구간
        if(r1 == 0 && r3 == 0)
        {
            Instantiate(map1zone, new Vector3(240, -39, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, -48, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, -56, 3.529f), Quaternion.identity);
        }
        else if(r1 == 0 && r3 == 1)
        {
            Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, -9, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, -17, 3.529f), Quaternion.identity);
        }
        else if(r1 == 1 && r3 == 0)
        {
            Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, -9, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, -17, 3.529f), Quaternion.identity);
        }
        else if(r1 == 1 && r3 == 1)
        {
            Instantiate(map1zone, new Vector3(240, 37.5f, 0), Quaternion.identity);
            Instantiate(Destination, new Vector3(302, 29, 0), Quaternion.identity);
            Instantiate(DeadZone, new Vector3(348, 21, 3.529f), Quaternion.identity);
        }
        // Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
    }
}
