using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SettingsPersistence
{
    public interface ISettingsPersistence
    {
        Language Language { get; set; }
        bool CurseWordFilterEnabled { get; set; }
        bool AudioEnabled { get; set; }
    }
}