using System;
using System.Collections.Generic;
using System.Numerics;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public partial class BaseFlyController : MonoBehaviour
{
    /// <summary>
    /// Store the ingestion info
    /// </summary>
    public Dictionary<IngestTypes, float> IngestedValues = new Dictionary<IngestTypes, float>();
    
    /// <summary>
    /// The speed of ingestion per second.
    /// </summary>
    public ValueContainer IngestSpeed = new ValueContainer(100);

    public BaseIngestCompletionProgressBarManager IngestManager;
    
    /// <summary>
    /// For Ingestable Scripts to call
    /// </summary>
    /// <param name="ingestType">The type of stuff ingested</param>
    /// <param name="ingestAmount">The amount ingested</param>
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

        IngestManager.IngestedValues = IngestedValues;
    }

    public void ClearIngestion()
    {
        IngestedValues = new Dictionary<IngestTypes, float>();
        IngestedValues.Add(IngestTypes.Fat,0);
        IngestedValues.Add(IngestTypes.Protein,0);
        IngestedValues.Add(IngestTypes.CarbonHydrate,0);
        IngestedValues.Add(IngestTypes.Water,0);
        IngestedValues.Add(IngestTypes.VitaminA,0);
        IngestedValues.Add(IngestTypes.VitaminB,0);
        IngestedValues.Add(IngestTypes.VitaminC,0);
        IngestedValues.Add(IngestTypes.Mineral,0);
        IngestedValues.Add(IngestTypes.Sodium,0);
    }
}