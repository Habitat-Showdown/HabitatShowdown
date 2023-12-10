using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Enums;

/// <summary>
/// 입력만 받아서 관리해준다.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public Player player { get; private set; }
    public Vector2 inputVec { get; private set; }


    #region #Unity_Function

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
            
    }

    #endregion
    
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}