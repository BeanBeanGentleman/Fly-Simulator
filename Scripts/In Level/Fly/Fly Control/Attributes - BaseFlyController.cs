using System.Collections.Generic;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.UI;
using UnityEngine;


public partial class BaseFlyController : MonoBehaviour
{
    public float BaseFlyMaxHP = 100;
    public ValueContainer MaxHP;
    private AutoResetCounter HPCounter;
    public ValueContainer HPReceptionModifier = new ValueContainer(1);
    public BaseDiscreteHPBarController D_HPBar;

    public Dictionary<IngestTypes, float> IngestionRecord;

    public GameObject EndScreenGameObject;
    
    /// <summary>
    /// For the fly taking damage
    /// </summary>
    /// <param name="Val">The damage that the fly will take. This should be positive if the fly is losing hp.</param>
    public void TakeDamage(float Val, string Message = "Whoops")
    {
        if (HPCounter.IsZeroReached(Val * HPReceptionModifier.FinalVal(), false, false))
        {
            this.Dies(Message);
        }

        if (D_HPBar == null)
        {
            var a = FindObjectOfType<HealthBar>();
            a.setValue(a.hp_bar.value - Val);
        }
        else
        {
            D_HPBar.HPProgress = HPCounter.Temp / HPCounter.Max;
        }

    }

    public virtual void Dies(string Message = "Whoops")
    {
        if(EndScreenGameObject != null) EndScreenGameObject.SetActive(true);
    }

}
