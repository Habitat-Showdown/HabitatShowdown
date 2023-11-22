using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSort : MonoBehaviour
{
    [SerializeField]
    private GameObject otherSort;
    [SerializeField]
    private GameObject otherSort2;
    [SerializeField]
    private GameObject mySort;
    public void ChgSort()
    {
        otherSort.SetActive(false);
        otherSort2.SetActive(false);
        mySort.SetActive(true);
    }
}
