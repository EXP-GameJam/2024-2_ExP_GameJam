using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_HeadAnim : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        C_OnHeadClick.HeadDown -= HeadDown;
        C_OnHeadClick.HeadUp -= HeadUp;
        C_OnHeadClick.HeadDown += HeadDown;
        C_OnHeadClick.HeadUp += HeadUp;
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
        anim.SetInteger("creditNum", C_OnHeadClick.creditNum);
    }
}
