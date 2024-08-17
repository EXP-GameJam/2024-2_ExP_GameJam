using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        Color savedColor = this.GetComponent<Image>().color;
        while (true)
        {
            Color CurrentColor = this.GetComponent<Image>().color;
            if(CurrentColor.a == 1.0f)
            {
                CurrentColor.a = 0.0f;
            }
            else
            {
                CurrentColor.a = 1.0f;
            }
            this.GetComponent<Image>().color = CurrentColor;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
