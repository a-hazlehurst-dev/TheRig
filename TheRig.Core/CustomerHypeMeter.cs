using System;
using TheRig.Core.Interfaces;

namespace TheRig.Core
{
    public class CustomerHypeMeter : IMeter
    {
        public CustomerHypeMeter(float min, float max, float current, string name)
        {
            Max = max;
            Min = min;
            Current = current;
            Name = name;
        }

        public float Max { get; private set; }
        public float Min { get; private set; }
        public float Current { get; set; }
        public void Change(float value)
        {
            if (value > 0.0f )
            {
                if (Current + value > Max)
                {
                    Current = Max;
                }
                else
                {
                    Current += value;
                }
            }
            if (value < 0.0f)
            {
                if (Current - value < Min)
                {
                    Current = Min;
                }
                else
                {
                    Current += value;
                }
            }
        }
        public string Name { get; }
    }
}
