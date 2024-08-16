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
    }

    public IEnumerator HeadDown()
    {
        float time = 0;
        while (!headUpTrigger)
        {
            currentHP -= (linearCoef * time + quadraticCoef * time * time);
            hpText.text = ((int)currentHP).ToString();

            time += Time.deltaTime;
            yield return null;
        }
        if (currentHP < 0)
        {
            hpText.text = "Died";
        }
        else HeadUp(time);
    }

    public void PointerDown() => StartCoroutine(HeadDown());
    public void PointerUp() => headUpTrigger = true;

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
    }

    private void Awake()
    {
        SetGauge();
    }
}
