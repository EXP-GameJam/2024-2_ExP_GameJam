using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ment : MonoBehaviour
{
    public static string[] ment = {
        "절대 말 안 해!",
        "난 잘못한 거 없어!",
        "그냥 친구라니까!",
        "이 손 놔 줘!!",
        "숨 막혀 숨!!",
        "헉 헉 미안해!!",
        "살려주세요!",
        "진짜 죽겠어",
        "다 말할게!!!",
        "네 친구 미영이랑 갔어",
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
