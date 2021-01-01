namespace Assets.Scripts.Types
{
    
    [System.Serializable]
    public class Configuration
    {
        public Language Language { get; set; }
        public bool AudioEnabled { get; set; }
        public bool CurseWordFilterEnabled { get; set; }
    }
}