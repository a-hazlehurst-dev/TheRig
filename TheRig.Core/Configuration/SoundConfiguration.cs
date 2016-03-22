namespace TheRig.Core.Configuration
{
    public class SoundConfiguration
    {
        public int Max {  get { return 10; } }
        public int Min {  get { return 0; } }
        public int MasterVolume { get; set; }
        public int MusicVolume { get; set; }
        public int EffectsVolume { get; set; }
        public int GuiVolume { get; set; }
        public int VoiceVolume { get; set; }
    }
}
