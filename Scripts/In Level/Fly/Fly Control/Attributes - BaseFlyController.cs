using System.Collections.Generic;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.UI;
using UnityEngine;
using UnityEngine.UI;


public partial class BaseFlyController : MonoBehaviour
{
    public float BaseFlyMaxHP = 100;
    public ValueContainer MaxHP;
    private AutoResetCounter HPCounter;
    public ValueContainer HPReceptionModifier = new ValueContainer(1);
    public BaseDiscreteHPBarController D_HPBar;

    public Text EndScreenGameObject;
    
    /// <summary>
    /// For the fly taking damage
    /// </summary>
    /// <param name="Val">The damage that the fly will take. This should be positive if the fly is losing hp.</param>
    public void TakeDamage(float Val, string Message = "Whoops\n(Alt+F4)")
    {
        if (HPCounter.IsZeroReached(Val * HPReceptionModifier.FinalVal(), false, false))
        {
            this.Dies(Message);
        }

        if (D_HPBar == null)
        {
            var a = FindObjectOfType<HealthBar>();
            if (a != null) a.setValue(a.hp_bar.value - Val);
        }
        else
        {
            D_HPBar.HPProgress = HPCounter.Temp / HPCounter.Max;
        }

    }
    /// <summary>
    /// For the fly recover from damage
    /// </summary>
    /// <param name="Val">The heal amount that the fly will take. This should be positive if the fly is getting hp.</param>
    public void Heal(float Val)
    {
        HPCounter.Temp = Mathf.Clamp(HPCounter.Temp + Val, 0, HPCounter.Max);
        if (D_HPBar == null)
        {
            var a = FindObjectOfType<HealthBar>();
            if (a != null) a.setValue(a.hp_bar.value - Val);
        }
        else
        {
            D_HPBar.HPProgress = HPCounter.Temp / HPCounter.Max;
        }
    }

    public virtual void Dies(string Message = "Whoops\n(Alt+F4)")
    {
        if (EndScreenGameObject != null)
        {
            EndScreenGameObject.transform.parent.gameObject.SetActive(true);
            EndScreenGameObject.text = Message;
            Time.timeScale = 0;
        }
    }

}
