using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfileViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNickname;

    [SerializeField] private Image sProfileImage;
    [SerializeField] private Image ProfileImage;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private TextMeshProUGUI Introdution;

    private void Awake()
    {
        BackendGameData.Instance.onGameDataLoadEvent.AddListener(UpdateGameData);
    }

    public void UpdateNickname()
    {
        // 닉네임이 없으면 gamer_id를 출력하고, 닉네임이 있으면 닉네임 출력
        textNickname.text = UserInfo.Data.nickname == null ? 
            UserInfo.Data.gamerId : UserInfo.Data.nickname;
        Debug.Log(textNickname.text);
    }

    public void UpdateGameData()
    {
        
    }
}