using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialog : MonoBehaviour
{

    public static DialogSettings[] dialogList =
    {
        new DialogSettings("�ڱ�� �� �׷�...", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("���� �� �� ��!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("�� �߸��� �� ����!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("�׳� ģ����ϱ�!", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("�� �� �� ��!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("�� ���� ��!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("�� �� �̾���!!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("����ּ���!", SpeechBubbleType.Hard, ColorType.Blue),
        new DialogSettings("��¥ �װھ�", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("�� ���Ұ�!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("�� ģ�� �̿��̶� ����", SpeechBubbleType.Normal, ColorType.Black),
    };

    private void Awake()
    {
        OnHeadClick.HeadUp += HeadUp;
    }

    public void HeadUp() => SpawnDialogPrefab();

    public static void SpawnDialogPrefab()
    {
        float hp = Gauge.currentHP;
        if (60 < hp && hp <= 100) DialogManager.Instance.CreateDialog(dialogList[Random.Range(1, 4)]);
        else if (30 < hp && hp <= 60) DialogManager.Instance.CreateDialog(dialogList[Random.Range(4, 6)]);
        else if (10 < hp && hp <= 30) DialogManager.Instance.CreateDialog(dialogList[Random.Range(6, 8)]);
        else if (0 < hp && hp <= 10) DialogManager.Instance.CreateDialog(dialogList[Random.Range(8, 10)]);
    }
}
