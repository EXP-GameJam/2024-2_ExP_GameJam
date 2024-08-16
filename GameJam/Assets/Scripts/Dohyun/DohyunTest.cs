using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DohyunTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log(SheetManager.Instance.SheetData.TestDohyun[1].A);
    }
}
