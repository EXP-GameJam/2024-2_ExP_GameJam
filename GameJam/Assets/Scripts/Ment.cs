using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ment : MonoBehaviour
{
    public static string[] ment = {
        "���� �� �� ��!",
        "�� �߸��� �� ����!",
        "�׳� ģ����ϱ�!",
        "�� �� �� ��!!",
        "�� ���� ��!!",
        "�� �� �̾���!!",
        "����ּ���!",
        "��¥ �װھ�",
        "�� ���Ұ�!!!",
        "�� ģ�� �̿��̶� ����",
    };

    public static string GetMent()
    {
        float hp = Gauge.currentHP;
        if (hp < 0 && hp <= 10) return ment[0];
        else if (hp < 10 && hp <= 20) return ment[1];
        else if (hp < 20 && hp <= 30) return ment[2];
        else if (hp < 30 && hp <= 40) return ment[3];
        else if (hp < 40 && hp <= 50) return ment[4];
        else if (hp < 50 && hp <= 60) return ment[5];
        else if (hp < 60 && hp <= 70) return ment[6];
        else if (hp < 70 && hp <= 80) return ment[7];
        else if (hp < 80 && hp <= 90) return ment[8];
        else if (hp < 90 && hp <= 100) return ment[9];
        else return null;
    }
}
