using System;
using TheRig.Core.Interfaces;

namespace TheRig.Core
{
    public class Meter : IMeter
    {
        public Meter(float min, float max, float current, string name, int group)
        {
            Max = max;
            Min = min;
            Current = current;
            Name = name;
            Group = group;
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
        public int Group { get;  }
    }
}
