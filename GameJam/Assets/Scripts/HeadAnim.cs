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
    }

    public void HeadDown() => anim.SetBool("isHeadDown", true);
    public void HeadUp() { anim.SetBool("isHeadDown", false); anim.SetFloat("HP", Gauge.currentHP); }
}
