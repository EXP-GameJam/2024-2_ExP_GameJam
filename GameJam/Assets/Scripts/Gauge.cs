using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public TMP_Text hpText;

    public static float currentHP;
    public int truthMinHP;
    public int truthMaxHP;

    public static bool isFirstTry = true;
    public static bool isFail = false;
    public static bool isSuccess = false;

    public float linear = 0.004f;
    public float quadratic = 0.0005f;

    private void Awake()
    {
        OnHeadClick.HeadDown += HeadDown;
        OnHeadClick.HeadUp += HeadUp;
    }

    private void Start()
    {
        SetGauge();
    }

    public void HeadDown() => StartCoroutine(DecreaseHP());
    public void HeadUp() => StopHP();
    public void SetGauge()
    {
        currentHP = 100;
        truthMinHP = 0;// Random.Range(0, 16);
        truthMaxHP = truthMinHP + 5;
        isFail = false;
        isSuccess = false;
        isFirstTry = true;

        PrintHP();
    }

    public float time = 0;
    public IEnumerator DecreaseHP()
    {
        time = 0;
        while (true)
        {
            currentHP -= (linear * time + quadratic * time * time);
            PrintHP();

            time += Time.deltaTime;
            yield return null;
        }
    }

    public void End() => OnHeadClick.End();

    public void PrintHP() => hpText.text = ((int)currentHP).ToString();

    public void StopHP()
    {
        StopAllCoroutines();
        if (currentHP < 0)
        {
            isFail = true;
            hpText.text = "Died";
            OnHeadClick.Disable();
            TimeAttack.Disable();
            EndingScript.EndingNum = 1;
            Invoke("End", 3);
        }

        else if (truthMinHP < currentHP && currentHP < truthMaxHP)
        {
            isSuccess = true;
            hpText.text = "Success";
            OnHeadClick.Disable();
            TimeAttack.Disable();
            if (isFirstTry) { EndingScript.EndingNum = 3;
                Invoke("End", 3);
            } //Ending
            else
            {
                EndingScript.EndingNum = 2;
                Invoke("End", 3);
            }
        }

        else { Heal(time); isFirstTry = false; }
    }

    public void Heal(float time)
    {
        if (time < 1) currentHP += 10;
        else if (1 < time && time < 3) currentHP += 6;
        else if (3 < time) currentHP += 4;
        currentHP = Mathf.Min(currentHP, 100);

        PrintHP();
    }

}
