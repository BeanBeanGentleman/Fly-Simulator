using System;

namespace Genral
{
    /// <summary>
    /// Modifier for FlyValueContainer
    /// </summary>
    [Serializable]
    public class Modifier
    {
        /// <summary>
        /// Is this a multiplier? False make this a absolute value bonus.
        /// </summary>
        public bool IsMultiply;
        public float Value;
        /// <summary>
        /// The order this will be applied. Based on string order and modifiers will be applied from 0-9-a-z-A-Z
        /// </summary>
        public string Order;
        
        public Modifier(bool isMultiply, float value, string order)
        {
            IsMultiply = isMultiply;
            Value = value;
            Order = order;
        }

        public static readonly Modifier NoBonusModifier = new Modifier(false, 0, "NULL");
    }
}