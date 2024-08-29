using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Bubble : MonoBehaviour
{
    public GameObject bigBubble, smallBubble;
    public GameObject parent;

    private void Awake()
    {
        C_OnHeadClick.HeadDown -= HeadDown;
        C_OnHeadClick.HeadUp -= HeadUp;
        C_OnHeadClick.HeadDown += HeadDown;
        C_OnHeadClick.HeadUp += HeadUp;
    }

    public void HeadDown() {
        StartCoroutine(SpawnBubble()); }
    public void HeadUp() => StopAllCoroutines();
    
    public IEnumerator SpawnBubble()
    {
        while (true) {
            float bps = GetBPS();
            GameObject bubblePrefab = (Random.Range(0, 2) == 0 ? bigBubble : smallBubble);
            GameObject bubble = Instantiate(bubblePrefab, parent.transform);

            bubble.transform.localPosition = new Vector2(Random.Range(-300, 300), Random.Range(-350, 250));
            Destroy(bubble, 0.666f);

            AudioManager.Instance.SFXPlay("Bubble_Pop_0" + Random.Range(1, 4).ToString());

            yield return new WaitForSeconds(1f/bps);
        }
    }

    public float GetBPS()
    {
        return Random.Range(2, 36);
    }
}
