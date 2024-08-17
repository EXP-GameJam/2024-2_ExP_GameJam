using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAnim : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        OnHeadClick.HeadDown += HeadDown;
        OnHeadClick.HeadUp += HeadUp;
        anim = GameObject.Find("Face").GetComponent<Animator>();
    }

    public void HeadDown()
    {
        if(anim == null)
            anim = GameObject.Find("Face").GetComponent<Animator>();
        anim.SetBool("isHeadDown", true);
    }
    public void HeadUp()
    {
        if (anim == null)
            anim = GameObject.Find("Face").GetComponent<Animator>();
        anim.SetBool("isHeadDown", false);
        anim.SetFloat("HP", Gauge.currentHP);
    }
}
