using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpawnDialog : MonoBehaviour
{

    public static DialogSettings[] dialogList =
    {
        new DialogSettings("~ CREDIT ~", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("기획 유현모!!!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("기획 유희원!!!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("플밍 김유찬!!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("플밍 김다산!!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("플밍 김도현!!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("그래픽 김영준!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("그래픽 이유강!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("그래픽 이지영!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("사운드 백소현!!!", SpeechBubbleType.Panic, ColorType.Purple),
        new DialogSettings("플레이해 주셔서 감사합니다...", SpeechBubbleType.Normal, ColorType.Black),
    };

    private void Awake()
    {
        C_OnHeadClick.HeadUp += HeadUp;
        
    }

    private void Start()
    {
        C_DialogManager.Instance.CreateDialog(dialogList[0]);
    }

    public void HeadUp() => StartCoroutine(SpawnDialogPrefab());

    public IEnumerator SpawnDialogPrefab()
    {
        yield return null;

        C_DialogManager.Instance.CreateDialog(dialogList[C_OnHeadClick.creditNum]);
    }
}
