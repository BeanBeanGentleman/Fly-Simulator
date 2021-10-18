using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Genral
{
    /// <summary>
    /// This is Container for fly attributes. Values can and should be modified by Modifiers. Use FinalVal() to get the modified values.
    /// </summary>
    [Serializable]
    public class ValueContainer
    {
        public readonly float BaseVal;
        [SerializeField]
        public Dictionary<Guid, Modifier> Modifiers;
        
        /// <summary>
        /// Initialize the container
        /// </summary>
        /// <param name="theBaseVal">The base value of the value container</param>
        public ValueContainer(float theBaseVal)
        {
            BaseVal = theBaseVal;
            Modifiers = new Dictionary<Guid, Modifier>();
        }
        
        
        /// <summary>
        /// Get the final value modified by modifiers. Modifiers will go through by order 0-9-A-Z-a-z.
        /// </summary>
        /// <returns>The final value</returns>
        public float FinalVal()
        {
            float result = BaseVal;
            var modifiers = from mod in Modifiers.Values orderby mod.Order select mod;
            foreach (Modifier bonus in modifiers)
            {
                result = bonus.IsMultiply ? result * bonus.Value : result + bonus.Value;
            }

            return result;
        }
        /// <summary>
        /// Make the modifier nullified in terms of effect
        /// </summary>
        /// <param name="theGuid">The corresponding Guid for the modifier</param>
        public void SetNoBonusModifier(Guid theGuid)
        {
            if (this.Modifiers.ContainsKey(theGuid)) this.Modifiers[theGuid] = Modifier.NoBonusModifier;
            else this.Modifiers.Add(theGuid, Modifier.NoBonusModifier);
        }
        /// <summary>
        /// Set the modifier
        /// </summary>
        /// <param name="theGuid">The corresponding Guid for the modifier</param>
        /// <param name="theModifier">The Modifier</param>
        public void SetModifier(Guid theGuid, Modifier theModifier)
        {
            if (this.Modifiers.ContainsKey(theGuid)) this.Modifiers[theGuid] = theModifier;
            else this.Modifiers.Add(theGuid, theModifier);
        }
    }
}