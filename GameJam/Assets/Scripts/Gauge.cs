using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public TMP_Text hpText;

    public static float currentHP;
    public int truthMinHP;
    public int truthMaxHP;

    public float linearCoef = 0.01f;
    public float quadraticCoef = 0.001f;

    private void Awake()
    {
        OnHeadClick.HeadDown += HeadDown;
        OnHeadClick.HeadUp += HeadUp;

        SetGauge();
    }

    public void HeadDown() => StartCoroutine(DecreaseHP());
    public void HeadUp() => StopHP();
    public void SetGauge()
    {
        currentHP = 100;
        truthMinHP = Random.Range(0, 22);
        truthMaxHP = truthMinHP + 8;

        PrintHP();
    }

    public float time = 0;
    public IEnumerator DecreaseHP()
    {
        time = 0;
        while (true)
        {
            currentHP -= (linearCoef * time + quadraticCoef * time * time);
            PrintHP();

            time += Time.deltaTime;
            yield return null;
        }
    }

    public void PrintHP() => hpText.text = ((int)currentHP).ToString();

    public void StopHP()
    {
        StopAllCoroutines();
        if (currentHP < 0)
        {
            currentHP = -1;
            hpText.text = "Died";
            OnHeadClick.Disable();
        }

        else if (truthMinHP < currentHP && currentHP < truthMaxHP)
        {
            hpText.text = "Success";
            OnHeadClick.Disable();
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

}
