using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using UnityEngine;

public class SheetManager : ManagerSingle<SheetManager>, IInit
{
    public SheetData SheetData;

    public void Init()
    {
        ParsingSheetData();
    }

    /// <summary>
    /// Data폴더에 있는 모든 시트 데이터를 파싱
    /// </summary>
    /// <returns>파싱된 SheetData</returns>
    private SheetData ParsingSheetData()
    {
        SheetData ??= new();

        TextAsset[] textAssets = Resources.LoadAll<TextAsset>("Data");

        foreach (TextAsset textAsset in textAssets)
        {
            Type variableType = Type.GetType(textAsset.name);
            ParsingSheetData(variableType, textAsset.text);
        }

        return SheetData;
    }

    /// <summary>
    /// 해당 시트 데이터를 파싱
    /// </summary>
    /// <param name="variableType">파싱할 데이터 타입</param>
    /// <param name="fileData">파싱할 데이터</param>
    private void ParsingSheetData(Type variableType, string fileData)
    {
        IList myList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(variableType));

        foreach (object element in ParsingData(variableType, fileData))
        {
            myList.Add(Convert.ChangeType(element, variableType));
        }
        typeof(SheetData).GetField(variableType.FullName).SetValue(SheetData, myList);
    }

    /// <summary>
    /// 시트 데이터에서 해당 변수의 데이터가 어떤 열에 있는지 세팅
    /// </summary>
    /// <param name="line">시트 데이터 첫번 째 행</param>
    private Dictionary<string, int> SetVariableIndex(string line)
    {
        Dictionary<string, int> variableIndex = new();

        string[] fields = line.TrimSplit("\t");

        for (int i = 0; i < fields.Length; i++)
            variableIndex[fields[i]] = i;

        return variableIndex;
    }

    /// <summary>
    /// 해당 string Data를 파싱
    /// </summary>
    /// <param name="type"> 파싱 타입 </param>
    /// <param name="stringText"> Raw string Data </param>
    /// <returns> 파싱된 List {type} </returns>
    private List<object> ParsingData(Type type, string stringText)
    {
        List<object> data = new();

        string[] lines = stringText.Split("\n");

        foreach (string line in lines.Skip(1))
        {
            if (string.IsNullOrEmpty(line.Trim()))
                continue;
            Dictionary<string, int> variableIndex = SetVariableIndex(lines[0]);
            object lineData = SetLineData(Activator.CreateInstance(type), line, variableIndex);
            data.Add(lineData);
        }

        return data;
    }

    /// <summary>
    /// 시트 데이터에서 한 행의 데이터를 생성
    /// </summary>
    /// <param name="data">시트 데이터</param>
    /// <param name="line">해당 행</param>
    /// <returns></returns>
    private object SetLineData(object data, string line, Dictionary<string, int> variableIndex)
    {
        string[] values = line.TrimSplit("\t");

        foreach (KeyValuePair<string, int> pair in variableIndex)
        {
            string[] variableNames = pair.Key.TrimSplit("_");

            Type type = data.GetType();
            FieldInfo fieldInfo = null;
            object target = data;

            bool isFirst = true;
            foreach (string  variableName in variableNames)
            {
                if (!isFirst)
                {
                    if(fieldInfo.GetValue(target) == null)
                        fieldInfo.SetValue(target, Activator.CreateInstance(type));
                    target = fieldInfo.GetValue(target);
                }

                fieldInfo = type.GetField(variableName);
                type = fieldInfo.FieldType;

                isFirst = false;
            }

            fieldInfo.SetValue(target, values[pair.Value].ToType(type));
        }

        return data;
    }
}
