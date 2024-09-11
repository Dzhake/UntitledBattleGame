

namespace UntitledBattleGame
{
    public static class Settings
    {
        public static string SettingsPath = @"%USERPROFILE%/AppData/Local/Dzhake/Fool/settings.txt";
        public static string SettingsLocation = Environment.ExpandEnvironmentVariables(SettingsLocation);
        public static bool DefaultSettings = false;

        public static Dictionary<string, object> Values = new()
        {
            { "WasRun", false }
        };

        public static void Load()
        {
            if (File.Exists(SettingsLocation) && !DefaultSettings)
            {
                foreach (string line in File.ReadAllLines(SettingsLocation))
                {
                    string[] kv = line.Split(',');
                    if (kv.Length > 1)
                        Settings[kv[0]] = kv[1];
                }
            }
            else
            {
                Save(true,true);
            }
        }

        public static void Save(bool notify = true,bool create = false)
        {
            string text = "";
            foreach (KeyValuePair<string, string> kvp in Settings)
            {
                text += $"{kvp.Key},{kvp.Value}\n";
            }

            FileInfo file = new FileInfo(SettingsLocation);
            if (create)
            {
                file.Directory?.Create();
            }
            File.WriteAllText(SettingsLocation, text);
            if (notify)
            {
                ColorConsole.WriteLine($"{{#green}}Settings {(create ? "created" : "saved")} successfully!{{#}}");
            }
        }
    }
}
