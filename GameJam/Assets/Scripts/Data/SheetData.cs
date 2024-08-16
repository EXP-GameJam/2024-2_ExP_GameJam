using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ʈ ��ü ������ 
/// </summary>
[System.Serializable]
public class SheetData
{
    // �Ʒ��� �߰��� Ŭ������ List���·� �����Ѵ�
    //public List<StageMapData> StageMapData;
    public List<TestDohyun> TestDohyun;
    public List<DialogSettings> DialogSettings;
}

// �߰��� ���ϴ� ��Ʈ �������� �� ���� �����͸� �����ϴ� Ŭ������ ��Ʈ �������� �̸��� �����ϰ� �ϳ� ������ش�

/* ����
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