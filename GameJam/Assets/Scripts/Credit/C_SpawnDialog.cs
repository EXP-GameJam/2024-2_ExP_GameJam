using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpawnDialog : MonoBehaviour
{

    public static DialogSettings[] dialogList =
    {
        new DialogSettings("~ CREDIT ~", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("��ȹ ������!!!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("��ȹ �����!!!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("�ù� ������!!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("�ù� ��ٻ�!!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("�ù� �赵��!!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("�׷��� �迵��!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("�׷��� ������!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("�׷��� ������!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("���� �����!!!", SpeechBubbleType.Panic, ColorType.Purple),
        new DialogSettings("�÷����� �ּż� �����մϴ�...", SpeechBubbleType.Normal, ColorType.Black),
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
