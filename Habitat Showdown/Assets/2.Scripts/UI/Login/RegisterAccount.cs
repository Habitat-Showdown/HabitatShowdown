using System;
using BackEnd;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _2.Scripts.UI.Login
{
    public class RegisterAccount : LoginBase
    {
        [SerializeField] private Image imageID; // ID 필드 색상 변경
        [SerializeField] private TMP_InputField inputFieldID; // ID 필드 텍스트 정보 추출
        [SerializeField] private Image imagePW; // PW 필드 색상 변경
        [SerializeField] private TMP_InputField inputFieldPW; // PW 필드 텍스트 정보 추출
        [SerializeField] private Image imageCheckPW; // CheckPW 필드 색상 변경
        [SerializeField] private TMP_InputField inputFieldCheckPW; // CheckPW 필드 텍스트 정보 추출
        [SerializeField] private Image imageEmail; // Email 필드 색상 변경
        [SerializeField] private TMP_InputField inputFieldEmail; // Email 필드 텍스트 정보 추출

        [SerializeField] private Button btnRegisterAccount;

        /// <summary>
        /// "계정 생성" 버튼을 눌렀을 때 호출
        /// </summary>
        public void OnClickRegisterAccount()
        {
            // 매개변수로 입력한 InputField UI의 색상과 Message 내용 초기화
            ResetUI(imageID, imagePW, imageCheckPW, imageEmail);
            
            // 필드 값이 비어있는지 체크
            if (IsFieldDataEmpty(imageID, inputFieldID.text, "아이디")) return;
            if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "비밀번호")) return;
            if (IsFieldDataEmpty(imageCheckPW, inputFieldCheckPW.text, "비밀번호 확인")) return;
            if (IsFieldDataEmpty(imageEmail, inputFieldEmail.text, "메일 주소")) return;
            
            // 비밀번호와 비밀번호 확인의 내용이 다를 때
            if (!inputFieldPW.text.Equals(inputFieldCheckPW.text))
            {
                GuideForIncorrectlyEnteredData(imageCheckPW, "비밀번호가 일치하지 않습니다.");
                return;
            }
            
            // 메일 형식 검사
            if (!inputFieldEmail.text.Contains("@"))
            {
                GuideForIncorrectlyEnteredData(imageEmail, "메일 형식이 잘못되었습니다. (ex. address@xx.xx");
                return;
            }
            
            // 계정 생성 버튼의 상호작용 비활성화
            btnRegisterAccount.interactable = false;
            SetMessage("계정 생성중입니다..");
            
            // 뒤끝 서버 계정 새성 시도
            CustomSignUp();
        }

        /// <summary>
        /// 계정 생성 시도 후 서버로부터 전달받은 Message를 기반으로 로직 처리
        /// </summary>
        private void CustomSignUp()
        {
            Backend.BMember.CustomSignUp(inputFieldID.text, inputFieldPW.text, callback =>
            {
                // "계정 생성" 버튼 상호작용 활성화
                btnRegisterAccount.interactable = true;

                // 계정 생성 성공
                if (callback.IsSuccess())
                {

                }
                // 계정 생성 실패
                else
                {

                }
            });

        }
    }
}