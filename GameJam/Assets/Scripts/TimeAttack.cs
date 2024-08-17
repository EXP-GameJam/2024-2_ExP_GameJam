using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    public GameObject Ddingdong;
    public GameObject Ddokddok1, Ddokddok2, Ddokddok3;
    public GameObject Kwangkwang1, Kwangkwang2;
    public GameObject KwangkwangPrefab1, KwangkwangPrefab2;
    public GameObject KwangkwangParent;

    private void Awake()
    {
        StartCoroutine(Timer());
    }
    
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);

        Ddingdong.SetActive(true);
        AudioManager.Instance.SFXPlay("Door_Bell");
        yield return new WaitForSeconds(2);
        Ddingdong.SetActive(false);

        yield return new WaitForSeconds(8);

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

        yield return new WaitForSeconds(8);

        Kwangkwang1.SetActive(true);
        AudioManager.Instance.SFXPlay("Door_Slam");
        yield return new WaitForSeconds(0.5f);
        Kwangkwang2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Kwangkwang1.SetActive(false);
        Kwangkwang2.SetActive(false);

        yield return new WaitForSeconds(3f); //25s
        StartCoroutine(Kwangkwang());
        StartCoroutine(KwangkwangSound());

        yield return new WaitForSeconds(5f);
        OnHeadClick.Disable();
        StopAllCoroutines();
        //gameover
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
            float scale = Random.Range(4f, 6f);

            prefab.transform.localScale = new Vector2(scale, scale);
            prefab.transform.localPosition = new Vector2(Random.Range(-230, 230), Random.Range(480, 590));
            GameObject kwangKwang = Instantiate(prefab, KwangkwangParent.transform);
            Destroy(kwangKwang, 1f);

            yield return new WaitForSeconds(0.3f);
        }
    }
}
