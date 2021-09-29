using System;
using System.Collections.Generic;
using System.Numerics;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public partial class BaseFlyController : MonoBehaviour, FlyInput.INormalFlyActions
{
    public Dictionary<IngestTypes, float> IngestedValues = new Dictionary<IngestTypes, float>();

    public virtual void IngestIn(IngestTypes ingestType, float ingestAmount)
    {
        if (!IngestedValues.ContainsKey(ingestType))
        {
            IngestedValues.Add(ingestType, ingestAmount);
        }
        else
        {
            IngestedValues[ingestType] += ingestAmount;
        }
    }
}