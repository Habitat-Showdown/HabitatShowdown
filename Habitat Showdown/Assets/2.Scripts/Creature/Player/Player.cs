using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterController;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; } }
    public StateMachine stateMachine { get; private set; }
    public Rigidbody2D rigidBody { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer spriter { get; private set; }


    public BaseWeapon weapon { get; set; }


    #region #캐릭터 스탯
    public float MaxHP     { get { return maxHP; } }
    public float CurrentHP { get { return currentHP; } }
    public float Damage     { get { return damage; } }
    public float MoveSpeed { get { return moveSpeed; } }

    [Header("캐릭터 스탯")]
    [SerializeField] protected float maxHP;
    [SerializeField] protected float currentHP;
    [SerializeField] protected float damage;
    [SerializeField] protected float moveSpeed;
    #endregion

    #region #Unity 함수
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            rigidBody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriter = GetComponent<SpriteRenderer>();
            DontDestroyOnLoad(gameObject);
            return;
        }
        DestroyImmediate(gameObject);
    }

    void Start()
    {
        InitStateMachine();
    }

    void Update()
    {
        stateMachine?.UpdateState();
    }

    void FixedUpdate()
    {
        stateMachine?.FixedUpdateState();
    }

    private void LateUpdate()
    {
        stateMachine?.LateUpdateState();
    }

    #endregion

    public void OnUpdateStat(float maxHP, float currentHP, float damage, float moveSpeed)
    {
        this.maxHP = maxHP;
        this.currentHP = currentHP;
        this.damage = damage;
        this.moveSpeed = moveSpeed;
    }

    private void InitStateMachine()
    {
       // 상태를 만들고 여기에서 등록하도록 한다.
       PlayerController controller = GetComponent<PlayerController>();
       stateMachine = new StateMachine(StateName.Idle, new IdleState(controller));
       stateMachine.AddState(StateName.Move, new MoveState(controller));
    }
}