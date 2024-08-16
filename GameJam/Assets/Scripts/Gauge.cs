using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public TMP_Text hpText;

    public float currentHP;
    public int truthMinHP;
    public int truthMaxHP;

    public float linearCoef = 0.01f;
    public float quadraticCoef = 0.001f;

    public bool headUpTrigger;
    public void SetGauge()
    {
        currentHP = 100;
        truthMinHP = Random.Range(0, 22);
        truthMaxHP = truthMinHP + 8;

        PrintHP();
    }

    public IEnumerator HeadDown()
    {
        float time = 0;
        while (!headUpTrigger)
        {
            currentHP -= (linearCoef * time + quadraticCoef * time * time);
            PrintHP();

            GetBubble();

            time += Time.deltaTime;
            yield return null;
        }
        if (currentHP < 0)
        {
            hpText.text = "Died";
        }
        else HeadUp(time);
    }

    public void PrintHP() => hpText.text = ((int)currentHP).ToString();
    public void PointerDown() => StartCoroutine(HeadDown());
    public void PointerUp() => headUpTrigger = true;

    public void GetBubble()
    {
        if (60 < currentHP && currentHP <= 100)
        {

        }
        else if (30 < currentHP && currentHP <= 60)
        {

        }
        else if (10 < currentHP && currentHP <= 30)
        {

        }
        else if (0 < currentHP && currentHP <= 10)
        {

        }
    }

    public void HeadUp(float time)
    {
        headUpTrigger = false;

        if (truthMinHP < currentHP && currentHP < truthMaxHP)
        {
            hpText.text = "Success";
        }
        else Heal(time);
    }

    public void Heal(float time)
    {
        if (time < 1) currentHP += 10;
        else if (1 < time && time < 3) currentHP += 5;
        else if (3 < time) currentHP += 2;
        currentHP = Mathf.Min(currentHP, 100);

        PrintHP();
    }

    public string GetMent()
    {
        if (currentHP < 0 && currentHP <= 10) return Ment.ment[0];
        else if (currentHP < 10 && currentHP <= 20) return Ment.ment[1];
        else if (currentHP < 20 && currentHP <= 30) return Ment.ment[2];
        else if (currentHP < 30 && currentHP <= 40) return Ment.ment[3];
        else if (currentHP < 40 && currentHP <= 50) return Ment.ment[4];
        else if (currentHP < 50 && currentHP <= 60) return Ment.ment[5];
        else if (currentHP < 60 && currentHP <= 70) return Ment.ment[6];
        else if (currentHP < 70 && currentHP <= 80) return Ment.ment[7];
        else if (currentHP < 80 && currentHP <= 90) return Ment.ment[8];
        else if (currentHP < 90 && currentHP <= 100) return Ment.ment[9];
        else return null;
    }

    private void Awake()
    {
        SetGauge();
    }
}
