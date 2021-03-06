﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CarnationVariableSectionPart
{
    /// <summary>
    /// Each CVSPField is check if changed every frame
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    internal class CVSPField : Attribute
    {
        private FieldInfo field;
        private static List<FieldInfo> parameters = new List<FieldInfo>();
        private static bool AttributesRetrieved = false;
        internal CVSPField(string fieldName)
        {
            field = typeof(ModuleCarnationVariablePart).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            if (field == null)
            {
                Debug.LogError($"[CRFP] Can't find field \"{fieldName}\" in {typeof(ModuleCarnationVariablePart).Name}");
                return;
            }
            foreach (var item in parameters)
                if (item.Name == field.Name)
                    return;
            parameters.Add(field);
        }
        internal static bool ValueChanged(IParameterMonitor part)
        {
            if (!AttributesRetrieved) RetrieveAttributes();
            if (Time.unscaledTime - part.LastEvaluatedTime > Time.unscaledDeltaTime)
            {
                if (part.IgnoreValueChangeOnce)
                {
                    part.IgnoreValueChangeOnce = false;
                    return part.CachedValueChangedInCurrentFrame = false;
                }
                var oldValues = part.OldValues;
                part.LastEvaluatedTime = Time.unscaledTime;
                int count = parameters.Count;
                if (oldValues.Count != count)
                {
                    oldValues.Capacity = count;
                    for (int i = 0; i < count; oldValues.Add(i++)) ;
                }
                for (int i = 0; i < count; i++)
                {
                    var currValue = parameters[i].GetValue(part);
                    if (!currValue.Equals(oldValues[i]))
                    {
                        oldValues[i] = currValue;
                        return part.CachedValueChangedInCurrentFrame = true;
                    }
                }
                return part.CachedValueChangedInCurrentFrame = false;
            }
            else return part.CachedValueChangedInCurrentFrame;
        }

        private static void RetrieveAttributes()
        {
            var f = typeof(ModuleCarnationVariablePart).GetFields();
            foreach (var item in f)
                item.GetCustomAttribute<CVSPField>();
            AttributesRetrieved = true;
        }
    }
}
