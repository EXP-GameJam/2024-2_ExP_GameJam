using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeAttack : MonoBehaviour
{
    public GameObject Ddingdong;
    public GameObject Ddokddok1, Ddokddok2, Ddokddok3;
    public GameObject Kwangkwang1, Kwangkwang2;
    public GameObject KwangkwangPrefab1, KwangkwangPrefab2;
    public GameObject KwangkwangParent;

    public static bool isDisabled = false;

    public Gauge gauge;

    public void End() => gauge.End();


    private void Awake()
    {
        StartCoroutine(Timer());
    }

    public static void Disable() => isDisabled = true;

    public void CheckDisable()
    {
        if (isDisabled) StopAllCoroutines();
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(9);

        Ddingdong.SetActive(true);
        AudioManager.Instance.SFXPlay("Door_Bell");
        yield return new WaitForSeconds(2);
        Ddingdong.SetActive(false);
        CheckDisable();

        yield return new WaitForSeconds(11);

        Ddokddok1.SetActive(true);
        AudioManager.Instance.SFXPlay("Door_Knock");
        yield return new WaitForSeconds(0.5f);
        Ddokddok2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Ddokddok3.SetActive(true);
        AudioManager.Instance.SFXPlay("Door_Knock");
        yield return new WaitForSeconds(1);
        Ddokddok1.SetActive(false);
        Ddokddok2.SetActive(false);
        Ddokddok3.SetActive(false);
        CheckDisable();

        yield return new WaitForSeconds(11);

        Kwangkwang1.SetActive(true);
        AudioManager.Instance.SFXPlay("Door_Slam");
        yield return new WaitForSeconds(0.5f);
        Kwangkwang2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Kwangkwang1.SetActive(false);
        Kwangkwang2.SetActive(false);
        CheckDisable();

        yield return new WaitForSeconds(3f); //25s
        StartCoroutine(Kwangkwang());
        StartCoroutine(KwangkwangSound());

        yield return new WaitForSeconds(8f);
        OnHeadClick.Disable();
        StopAllCoroutines();
        //gameover
        EndingScript.EndingNum = 0;

        Invoke("End", 3);
    }

    public IEnumerator KwangkwangSound()
    {
        while (true)
        {
            AudioManager.Instance.SFXPlay("Door_Slam");
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator Kwangkwang()
    {
        while (true)
        {
            GameObject prefab = (Random.Range(0, 2) == 0 ? KwangkwangPrefab1 : KwangkwangPrefab2);
            float scale = Random.Range(10f, 7f);

            prefab.transform.localScale = new Vector2(scale, scale);
            prefab.transform.localPosition = new Vector2(Random.Range(-400, 400), Random.Range(450, 800));
            GameObject kwangKwang = Instantiate(prefab, KwangkwangParent.transform);
            Destroy(kwangKwang, 1f);

            CheckDisable();
            yield return new WaitForSeconds(0.3f);
        }
    }
}
