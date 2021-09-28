using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Genral
{
    [Serializable]
    public class FlyValueContainer
    {
        public float BaseVal;
        protected Dictionary<GUID, Modifier> Modifiers;
        
        /// <summary>
        /// Initialize the container
        /// </summary>
        /// <param name="theBaseVal">The base value of the value container</param>
        public FlyValueContainer(float theBaseVal)
        {
            BaseVal = theBaseVal;
            Modifiers = new Dictionary<GUID, Modifier>();
        }
        
        
        /// <summary>
        /// Get the final value modified by modifiers. Modifiers will go through by order 0-9-a-z.
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

        public void SetNoBonusModifier(GUID theGuid)
        {
            if (this.Modifiers.ContainsKey(theGuid)) this.Modifiers[theGuid] = Modifier.NoBonusModifier;
            else this.Modifiers.Add(theGuid, Modifier.NoBonusModifier);
        }
        
        public void SetModifier(GUID theGuid, Modifier theModifier)
        {
            if (this.Modifiers.ContainsKey(theGuid)) this.Modifiers[theGuid] = theModifier;
            else this.Modifiers.Add(theGuid, theModifier);
        }
    }
}