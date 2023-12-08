using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹을 보관하는 변수
    public GameObject[] prefabs;
    
    // 풀을 담당하는 변수
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length]; // 배열 초기화
        for (int i = 0; i < prefabs.Length; i++)      // 리스트 초기화
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        
        // 선택한 인텍스의 풀에서 놀고(비활성화)있는 게임 오브젝트 가져오기
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // 발견한다면? select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }
        
        // 만약 못 찿았으면?
        if (!select)
        {
            // 새롭게 게임오브젝트를 하나 생성하고 select에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        
        return select;
    }
}
