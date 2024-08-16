using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public static class StringParsing
{
    /// <summary>
    /// String 데이터를 Type 으로 변환
    /// </summary>
    /// <param name="text"></param>
    /// <param name="type"></param>
    /// <param name="defaultValue">Parsing에 실패시 기본값</param>
    /// <returns></returns>
    public static bool TryStringToType(string text, Type type, out object result, object defaultValue = null, int lap = 1)
    {
        object value;
        bool isSuccess;

        if (type == typeof(int))
        {
            isSuccess = TryStringToInt(text, out int valueInt);
            value = valueInt;
        }
        else if (type == typeof(float))
        {
            isSuccess = TryStringToFloat(text, out float valueFloat);
            value = valueFloat;
        }
        else if (type == typeof(Vector2))
        {
            isSuccess = TryStringToVector2(text, out Vector2 valueVector2);
            value = valueVector2;
        }
        else if (type == typeof(Vector3))
        {
            isSuccess = TryStringToVector3(text, out Vector3 valueVector3);
            value = valueVector3;
        }
        else if (type == typeof(string))
        {
            if (text == "" && defaultValue != null)
                isSuccess = false;
            else
                isSuccess = true;
            value = text;
        }
        else if (type == typeof(Enum))
        {
            isSuccess = TryStringToEnum(text, out value);
        }
        else if (type.IsArray)
        {
            isSuccess = TryStringToTypeArray(text, type.GetElementType(), out object valueArray, lap);
            value = valueArray;
        }
        else if (type.FullName.StartsWith("System.Tuple") || type.FullName.StartsWith("System.ValueTuple"))
        {
            isSuccess = TryStringToTuple(text, type, out object valueTuple, lap);
            value = valueTuple;
        }
        else
        {
            isSuccess = TryStringToTuple(text, type, out object valueTuple, lap);
            value = valueTuple;
        }

        if (!isSuccess)
            result = defaultValue;
        else
            result = value;

        return isSuccess;
    }


    #region TryStringParsing
    /// <summary>
    /// String을 int형으로 변환
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool TryStringToInt(string text, out int value)
    {
        value = 0;

        if (string.IsNullOrEmpty(text.Trim()))
            return false;

        if (int.TryParse(text, out value))
            return true;
        else
            return false;
    }

    public static bool TryStringToFloat(string text, out float value)
    {
        value = 0;

        if (string.IsNullOrEmpty(text.Trim()))
            return false;

        if (float.TryParse(text, out value))
            return true;
        else
            return false;
    }
    public static bool TryStringToVector2(string text, out Vector2 value)
    {
        value = new Vector2(-1000, -1000);

        if (string.IsNullOrEmpty(text.Trim()))
            return false;

        string[] xy = text.TrimSplit(",");
        if (TryStringToFloat(xy[0], out float x) && TryStringToFloat(xy[1], out float y))
        {
            value = new Vector2(x, y);
            return true;
        }
        else
            return false;
    }
    public static bool TryStringToVector3(string text, out Vector3 value)
    {
        value = new Vector3(-1000, -1000, -1000);

        if (string.IsNullOrEmpty(text.Trim()))
            return false;

        string[] xyz = text.TrimSplit(",");
        if (TryStringToFloat(xyz[0], out float x) && TryStringToFloat(xyz[1], out float y) && TryStringToFloat(xyz[2], out float z))
        {
            value = new Vector3(x, y, z);
            return true;
        }
        else
            return false;
    }
    public static bool TryStringToEnum(string text, out object value)
    {
        string[] data = text.TrimSplit(".");
        Type enumType = Type.GetType(data[0]);

        Debug.Log(text);

        if (Enum.TryParse(enumType, data[1], out value))
            return true;
        else
            return false;
    }
    public static bool TryStringToTypeArray(string text, Type type, out object value, int lap = 1)
    {
        bool isSuccess = false;

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < lap; i++)
            stringBuilder.Append("|");

        string[] elements = text.TrimSplit(stringBuilder.ToString());
        object[] array = new object[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            isSuccess = TryStringToType(elements[i], type, out object element, lap + 1);
            array[i] = element;
        }

        if (elements.Length == 0)
        {
            isSuccess = false;
            array = new object[0];
        }

        value = array;

        return isSuccess;
    }
    public static bool TryStringToTuple(string text, Type type, out object value, int lap)
    {
        bool isSuccess;
        Type[] types = type.GenericTypeArguments;

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < lap; i++)
            stringBuilder.Append(",");

        var parts = text.TrimSplit(stringBuilder.ToString());

        if (parts.Length != types.Length)
            isSuccess = false;

        object[] elements = new object[types.Length];
        for (int i = 0; i < types.Length; i++)
        {
            if (!TryStringToType(parts[i], types[i], out object element, lap + 1))
            {
                isSuccess = false;
                value = default;
                return isSuccess;
            }
            elements[i] = element;
        }

        Type tupleType = typeof(ValueTuple<>).Assembly.GetType($"System.ValueTuple`{types.Length}").MakeGenericType(types);
        value = Activator.CreateInstance(tupleType, elements);
        isSuccess = true;

        return isSuccess;
    }

    #endregion

    public static object StringToType(string text, Type type, int lap = 1)
    {
        object value;

        if (type == typeof(int))
        {
            value = StringToInt(text);
        }
        else if (type == typeof(float))
        {
            value = StringToFloat(text);
        }
        else if (type == typeof(Vector2))
        {
            value = StringToVector2(text);
        }
        else if (type == typeof(Vector3))
        {
            value = StringToVector3(text);
        }
        else if (type == typeof(string))
        {
            value = text;
        }
        else if (type.IsArray)
        {
            value = StringToTypeArray(text, type.GetElementType(), lap);
        }
        else if (type.FullName.StartsWith("System.Tuple") || type.FullName.StartsWith("System.ValueTuple"))
        {
            value = StringToTuple(text, type, lap);
        }
        else if (type == typeof(bool))
        {
            value = bool.Parse(text);
        }
        else
        {
            TryStringToEnum(text, out value);
        }

        return value;
    }

    public static object StringToType(string text, Type type, object defaultValue, int lap = 1)
    {
        object value;
        bool isSuccess;

        if (type == typeof(int))
        {
            isSuccess = TryStringToInt(text, out int valueInt);
            value = valueInt;
        }
        else if (type == typeof(float))
        {
            isSuccess = TryStringToFloat(text, out float valueFloat);
            value = valueFloat;
        }
        else if (type == typeof(Vector2))
        {
            isSuccess = TryStringToVector2(text, out Vector2 valueVector2);
            value = valueVector2;
        }
        else if (type == typeof(Vector3))
        {
            isSuccess = TryStringToVector3(text, out Vector3 valueVector3);
            value = valueVector3;
        }
        else if (type == typeof(string))
        {
            if (text == "" && defaultValue != null)
                isSuccess = false;
            else
                isSuccess = true;
            value = text;
        }
        else if (type == typeof(Enum))
        {
            isSuccess = TryStringToEnum(text, out value);
        }
        else if (type.IsArray)
        {
            isSuccess = TryStringToTypeArray(text, type.GetElementType(), out object valueArray);
            value = valueArray;
        }
        else if (type.FullName.StartsWith("System.Tuple") || type.FullName.StartsWith("System.ValueTuple"))
        {
            isSuccess = TryStringToTuple(text, type, out object valueTuple, lap);
            value = valueTuple;
        }
        else if (type == typeof(bool))
        {
            isSuccess = TryStringToBool(text, out bool valueBool);
            value = valueBool;
        }
        else
        {
            isSuccess = TryStringToEnum(text, out value);
        }

        if (!isSuccess)
            value = defaultValue;

        return value;
    }

    public static Type StringToType<Type>(string text, int lap = 1)
    {
        Type value = default;

        if (value.GetType() == typeof(int))
            value = (Type)(object)StringToInt(text);
        else if (value.GetType() == typeof(float))
            value = (Type)(object)StringToFloat(text);
        else if (value.GetType() == typeof(Vector2))
            value = (Type)(object)StringToVector2(text);
        else if (value.GetType() == typeof(Vector3))
            value = (Type)(object)StringToVector3(text);
        else if (value.GetType().IsArray)
            value = (Type)(object)StringToTypeArray<Type>(text);
        else if (value.GetType().FullName.StartsWith("System.Tuple") || value.GetType().FullName.StartsWith("System.ValueTuple"))
        {
            value = (Type)StringToTuple(text, value.GetType(), lap);
        }

        return value;
    }

    #region StringParsing
    /// <summary>
    /// String을 int형으로 변환
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static int StringToInt(string text)
    {
        return int.Parse(text);
    }

    public static bool TryStringToBool(string text, out bool a)
    {
        return bool.TryParse(text, out a);
    }

    public static float StringToFloat(string text)
    {
        return float.Parse(text);
    }
    public static Vector2 StringToVector2(string text)
    {
        string[] xy = text.TrimSplit(",");
        return new Vector2(float.Parse(xy[0]), float.Parse(xy[1]));
    }
    public static Vector3 StringToVector3(string text)
    {
        string[] xyz = text.TrimSplit(",");
        return new Vector3(float.Parse(xyz[0]), float.Parse(xyz[1]), float.Parse(xyz[2]));
    }
    public static Enum StringToEnum<Enum>(string text) where Enum : struct, System.Enum
    {
        string[] data = text.TrimSplit(".");
        return System.Enum.Parse<Enum>(data[1]);
    }
    public static Type[] StringToTypeArray<Type>(string text, int lap = 1)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < lap; i++)
            stringBuilder.Append("|");

        string[] elements = text.TrimSplit(stringBuilder.ToString());
        Type[] array = new Type[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            array[i] = StringToType<Type>(elements[i], lap + 1);
        }

        return array;
    }
    public static object StringToTypeArray(string text, Type type, int lap = 1)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < lap; i++)
            stringBuilder.Append("|");

        string[] elements = text.TrimSplit(stringBuilder.ToString());
        object[] array = new object[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            array[i] = StringToType(elements[i], type, lap + 1);
        }

        return array;
    }
    public static Type StringToTuple<Type>(string text, int lap)
    {
        Type type = default;
        System.Type[] types = type.GetType().GenericTypeArguments;

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < lap; i++)
            stringBuilder.Append(",");

        var parts = text.TrimSplit(stringBuilder.ToString());

        if (parts.Length != types.Length)
            throw new ArgumentException("Tuple의 형식에 맞춰서 데이터를 입력해주세요.");

        object[] elements = new object[types.Length];
        for (int i = 0; i < types.Length; i++)
        {
            elements[i] = StringToType(parts[i], types[i], lap + 1);
        }

        System.Type tupleType = typeof(ValueTuple<>).Assembly.GetType($"System.ValueTuple`{types.Length}").MakeGenericType(types);

        return (Type)Activator.CreateInstance(tupleType, elements);
    }
    public static object StringToTuple(string text, Type type, int lap = 1)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < lap; i++)
            stringBuilder.Append(",");

        Type[] types = type.GenericTypeArguments;

        var parts = text.TrimSplit(stringBuilder.ToString());

        if (parts.Length != types.Length)
            throw new ArgumentException("Tuple의 형식에 맞춰서 데이터를 입력해주세요.");

        object[] elements = new object[types.Length];
        for (int i = 0; i < types.Length; i++)
        {
            elements[i] = StringToType(parts[i], types[i], lap + 1);
        }

        Type tupleType = typeof(ValueTuple<>).Assembly.GetType($"System.ValueTuple`{types.Length}").MakeGenericType(types);

        return Activator.CreateInstance(tupleType, elements);
    }

    #endregion
}