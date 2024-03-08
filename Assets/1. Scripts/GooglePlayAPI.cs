using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayAPI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {

        }
        else
        {
            Debug.Log("로그인 실패");
            //PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication);
        }
    }
}
