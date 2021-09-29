using System;

namespace Genral
{
    [Serializable]
    public class Modifier
    {
        public bool IsMultiply;
        public float Value;
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