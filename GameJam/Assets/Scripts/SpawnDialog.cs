using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialog : MonoBehaviour
{

    public static DialogSettings[] dialogList =
    {
        new DialogSettings("자기야 왜 그래...", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("절대 말 안 해!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("난 잘못한 거 없어!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("그냥 친구라니까!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("이 손 놔 줘!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("숨 막혀 숨!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("헉 헉 미안해!!", SpeechBubbleType.Hard, ColorType.Purple),
        new DialogSettings("살려주세요!", SpeechBubbleType.Hard, ColorType.Purple),
        new DialogSettings("진짜 죽겠어", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("다 말할게!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("네 친구 미영이랑 갔어", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("반응이 없다...", SpeechBubbleType.Normal, ColorType.Black),
    };

    private void Awake()
    {
        OnHeadClick.HeadUp += HeadUp;
        DialogManager.Instance.CreateDialog(dialogList[0]);
    }

    public void HeadUp() => StartCoroutine(SpawnDialogPrefab());

    public IEnumerator SpawnDialogPrefab()
    {
        yield return null;
        float hp = Gauge.currentHP;

        if (Gauge.isSuccess) DialogManager.Instance.CreateDialog(dialogList[10]);
        else if (Gauge.isFail) DialogManager.Instance.CreateDialog(dialogList[11]);

        else if (75 < hp && hp <= 100) DialogManager.Instance.CreateDialog(dialogList[Random.Range(1, 4)]);
        else if (50 < hp && hp <= 75) DialogManager.Instance.CreateDialog(dialogList[Random.Range(4, 6)]);
        else if (25 < hp && hp <= 50) DialogManager.Instance.CreateDialog(dialogList[Random.Range(6, 8)]);
        else if (0 < hp && hp <= 25) DialogManager.Instance.CreateDialog(dialogList[Random.Range(8, 10)]);
        
    }
}
