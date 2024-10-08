using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject bigBubble, smallBubble;
    public GameObject parent;

    private void Awake()
    {
        OnHeadClick.HeadDown -= HeadDown;
        OnHeadClick.HeadUp -= HeadUp;
        OnHeadClick.HeadDown += HeadDown;
        OnHeadClick.HeadUp += HeadUp;
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
        float hp = Gauge.currentHP;
        if (75 < hp && hp <= 100) return Random.Range(2, 4);
        else if (50 < hp && hp <= 75) return Random.Range(5, 9);
        else if (25 < hp && hp <= 50) return Random.Range(10, 16);
        else if (5 < hp && hp <= 25) return Random.Range(20, 26);
        else if (0 < hp && hp <= 5) return Random.Range(30, 36);

        else return 0;
    }
}
