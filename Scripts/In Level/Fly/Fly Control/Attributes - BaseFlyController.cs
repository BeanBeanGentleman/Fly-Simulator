using System.Collections.Generic;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.UI;
using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.UI;
>>>>>>> dev_tony


public partial class BaseFlyController : MonoBehaviour
{
    public float BaseFlyMaxHP = 100;
    public ValueContainer MaxHP;
    private AutoResetCounter HPCounter;
    public ValueContainer HPReceptionModifier = new ValueContainer(1);
    public BaseDiscreteHPBarController D_HPBar;

<<<<<<< HEAD
    public Dictionary<IngestTypes, float> IngestionRecord;
=======
    public Text EndScreenGameObject;
>>>>>>> dev_tony
    
    /// <summary>
    /// For the fly taking damage
    /// </summary>
    /// <param name="Val">The damage that the fly will take. This should be positive if the fly is losing hp.</param>
<<<<<<< HEAD
    public void TakeDamage(float Val, string Message = "Whoops")
=======
    public void TakeDamage(float Val, string Message = "Whoops\n(Alt+F4)")
>>>>>>> dev_tony
    {
        if (HPCounter.IsZeroReached(Val * HPReceptionModifier.FinalVal(), false, false))
        {
            this.Dies(Message);
        }

        if (D_HPBar == null)
        {
            var a = FindObjectOfType<HealthBar>();
<<<<<<< HEAD
            a.setValue(a.hp_bar.value - Val );
=======
            if (a != null) a.setValue(a.hp_bar.value - Val);
>>>>>>> dev_tony
        }
        else
        {
            D_HPBar.HPProgress = HPCounter.Temp / HPCounter.Max;
        }

    }
<<<<<<< HEAD

    public virtual void Dies(string Message = "Whoops")
    {
        var a = GameObject.FindGameObjectWithTag("EndScreen");
        a.SetActive(true);
=======
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
            // EndScreenGameObject.text = Message;
        }
    }

    public float GetHP()
    {
        return HPCounter.Temp;
>>>>>>> dev_tony
    }

}
