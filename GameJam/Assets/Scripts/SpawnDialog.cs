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
        new DialogSettings("�� �� �̾���!!", SpeechBubbleType.Hard, ColorType.Purple),
        new DialogSettings("����ּ���!", SpeechBubbleType.Hard, ColorType.Purple),
        new DialogSettings("��¥ �װھ�", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("�� ���Ұ�!!!", SpeechBubbleType.Panic, ColorType.Red),
        new DialogSettings("�� ģ�� �̿��̶� ����", SpeechBubbleType.Normal, ColorType.Black),
        new DialogSettings("������ ����...", SpeechBubbleType.Normal, ColorType.Black),
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
