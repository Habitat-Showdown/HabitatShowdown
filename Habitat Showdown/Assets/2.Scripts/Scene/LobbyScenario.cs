using System;
using UnityEngine;

public class LobbyScenario : MonoBehaviour
{
    [SerializeField] private UserInfo user;

    [SerializeField] private GameObject backPanel;
    [SerializeField] private GameObject createNickname;
    
    private void Awake()
    {
        user.GetUserInfoFromBackend();
    }

    public void FirstLogin()
    {
        print(UserInfo.Data.nickname);
        print(UserInfo.Data.gamerId);
        
        if (UserInfo.Data.nickname == UserInfo.Data.gamerId)
        {
            backPanel.SetActive(true);
            createNickname.SetActive(true);
        }
    }
}