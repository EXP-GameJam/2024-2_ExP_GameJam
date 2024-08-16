using UnityEngine;
using System;

public static class StringExtension
{
    public static Type ToType<Type>(this string text)
    {
        return StringParsing.StringToType<Type>(text);
    }

    public static object ToType(this string text, Type type)
    {
        return StringParsing.StringToType(text, type);
    }

    public static object ToType(this string text, Type type, object defaultValue)
    {
        return StringParsing.StringToType(text, type, defaultValue);
    }

    public static Type[] ToTypeArray<Type>(this string text)
    {
        return StringParsing.StringToTypeArray<Type>(text);
    }

    public static Enum ToEnum<Enum>(this string text) where Enum : struct, System.Enum
    {
        return StringParsing.StringToEnum<Enum>(text);
    }
}