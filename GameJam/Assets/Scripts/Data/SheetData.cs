using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 시트 전체 데이터 
/// </summary>
[System.Serializable]
public class SheetData
{
    // 아래에 추가한 클래스를 List형태로 선언한다
    //public List<StageMapData> StageMapData;
    public List<TestDohyun> TestDohyun;
    public List<DialogSettings> DialogSettings;
}

// 추가를 원하는 시트 데이터의 한 행의 데이터를 포함하는 클래스를 시트 데이터의 이름과 동일하게 하나 만들어준다

/* 예시
public class StageMapData
{
    public int Stage;
    public int Default;
    public int Random;
    public (int x, int y) RoomSize;
    public int MaxBigRoom;
}
*/

[System.Serializable]
public class TestDohyun
{
    public int A;
    public int B;
    public int C;
    public Test D;
    public Test E;
    public bool F;
}

public enum Test
{
    A,
    B,
    C
}