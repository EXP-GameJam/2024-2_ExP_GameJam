using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject bigBubble, smallBubble;
    public GameObject parent;

    private void Awake()
    {
        OnHeadClick.HeadDown += HeadDown;
        OnHeadClick.HeadUp += HeadUp;
    }

    public void HeadDown() => StartCoroutine(SpawnBubble());
    public void HeadUp() => StopAllCoroutines();
    
    public IEnumerator SpawnBubble()
    {
        while (true) {
            float bps = GetBPS();

            GameObject bubblePrefab = (Random.Range(0, 2) == 0 ? bigBubble : smallBubble);
            GameObject bubble = Instantiate(bubblePrefab, parent.transform);

            bubble.transform.localPosition = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
            Destroy(bubble, 0.5f);

            yield return new WaitForSeconds(1f/bps);
        }
    }

    public float GetBPS()
    {
        float hp = Gauge.currentHP;
        if (60 < hp && hp <= 100) return 5;
        else if (30 < hp && hp <= 60) return 10;
        else if (10 < hp && hp <= 30) return 15;
        else if (0 < hp && hp <= 10) return 20;

        else return 0;
    }
}
