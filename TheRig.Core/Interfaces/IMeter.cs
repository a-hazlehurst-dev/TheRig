namespace TheRig.Core.Interfaces
{
    public interface IMeter
    {
        float Max { get;}
        float Min { get;}
        float Current { get; set; }
        void Change(float value);
        string Name { get; }
    }
}
