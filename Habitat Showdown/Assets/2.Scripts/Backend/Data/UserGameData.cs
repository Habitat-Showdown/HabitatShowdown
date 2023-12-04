[System.Serializable]
public class UserGameData
{
    public int profileImageNum; // 현재 선택 중인 프로필 이미지의 숫자.
    public int characterNum; // 현재 선택 중인 캐릭터의 숫자
    public string Introduction; // 소개글

    public void Reset()
    {
        profileImageNum = 1;
        characterNum = 1;
        Introduction = "";
    }
}