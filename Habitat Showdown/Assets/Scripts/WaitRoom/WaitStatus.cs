using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject otherBtn;
    [SerializeField]
    private GameObject myBtn;
    public void ChgStatus()
    {
        otherBtn.SetActive(true);
        myBtn.SetActive(false);
    }
}
