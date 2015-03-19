using ColossalFramework;
using ICities;
using SkylineToolkit.PermaMod;
using System;
using UnityEngine;

namespace SkylineToolkit
{
    public class SkylineToolkitMod : IUserMod
    {

        private static GameObject permaModGameObject;

        private static GameObject mainMenuModGameObject;

        public static GameObject PermaModGameObject
        {
            get
            {
                return permaModGameObject;
            }
            private set
            {
                permaModGameObject = value;
            }
        }

        public static SkylineToolkitPermaMod PermaModComponent
        {
            get
            {
                if (PermaModGameObject == null)
                {
                    return null;
                }

                return PermaModGameObject.GetComponent<SkylineToolkitPermaMod>();
            }
        }

        public static GameObject MainMenuModGameObject
        {
            get
            {
                return mainMenuModGameObject;
            }
            private set
            {
                mainMenuModGameObject = value;
            }
        }

        public static MainMenuModification MainMenuModComponent
        {
            get
            {
                if (MainMenuModGameObject == null)
                {
                    return null;
                }

                return MainMenuModGameObject.GetComponent<MainMenuModification>();
            }
        }

        public string Description
        {
            get
            {
                return "Toolkit for easier Cities: Skylines mod creation. NOTE: Some features of this mod will be enabled even when it's disabled here."
                    + " If you enable this mod, achievements WON'T get disabled even for other mods.";
            }
        }

        public string Name
        {
            get
            {
                return "SkylineToolkit";
            }
        }

        public SkylineToolkitMod()
        {
            // The following method calls are hooks to initialize our permanent mod and main menu modification
            InitializePermaMod();
            InitializeMainMenuMod();

            InitializeSettings();
        }

        private void InitializeSettings()
        {
            Log.Debug(GameSettings.FindSettingsFileByName(SkylineToolkitSettings.settingsFile) == null ? "null" : "not null");

            try
            {
                SettingsFile[] settingsFiles = new SettingsFile[1];
                SettingsFile settingsFile = new SettingsFile()
                {
                    fileName = SkylineToolkitSettings.settingsFile
                };

                settingsFiles[0] = settingsFile;

                GameSettings.AddSettingsFile(settingsFiles);
            }
            catch (GameSettingsException e)
            {
                Log.Debug("GameSettingsException: " + e.ToString());
            }
            catch (Exception e)
            {
                Log.Debug("Exception: " + e.ToString());
            }

            Log.Debug(GameSettings.FindSettingsFileByName(SkylineToolkitSettings.settingsFile) == null ? "null" : "not null");

            SkylineToolkitSettings settings = new SkylineToolkitSettings();
            Log.Debug("" + settings.testBool.value);
            settings.testBool.value = !settings.testBool.value;
            Log.Debug("" + settings.testBool.value);

            GameSettings.SaveAll();
        }

        private void InitializePermaMod()
        {
            GameObject toolkitObject = new GameObject("___SkylineToolkit");

            SkylineToolkitPermaMod component = toolkitObject.AddComponent<SkylineToolkitPermaMod>();

            PermaModGameObject = toolkitObject;
        }

        private void InitializeMainMenuMod()
        {
            GameObject mainMenuObject = new GameObject("___SkylineToolkit_MainMenuMod");

            MainMenuModification component = mainMenuObject.AddComponent<MainMenuModification>();

            MainMenuModGameObject = mainMenuObject;
        }
    }
}
