using System.Collections;
using System.Collections.Generic;
using EnemyState;
using UnityEngine;

public enum EnemyStates
{
    Move,
    Attack,
    Hit,
    Dead,
}

public class Enemy : MonoBehaviour
{
    #region #몬스터 스탯

    [Header("몬스터 스탯")]
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;
    
    public float MaxHp
    {
        get => maxHp;
        set => Mathf.Max(0, value);
    }
    public float CurrentHp
    {
        get => currentHp;
        set => Mathf.Max(0, value);
    }
    public float Damage
    {
        get => damage;
        set => Mathf.Max(0, value);
    }
    public float MoveSpeed
    {
        get => moveSpeed;
        set => Mathf.Max(0, value);
    }
    
    #endregion

    private State<Enemy>[] states;
    private State<Enemy> currentState;
}
