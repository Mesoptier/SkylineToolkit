using ColossalFramework;
using SkylineToolkit.Settings;

namespace SkylineToolkit
{
    class SkylineToolkitSettings : ModSettings
    {
        public static string settingsFile = "skylineToolkitSettings";

        public SavedBool testBool = new SavedBool("testBool", settingsFile);
    }
}
