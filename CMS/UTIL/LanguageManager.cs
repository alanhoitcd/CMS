using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.UTIL
{
    public class LanguageManager
    {
        private static readonly ResourceManager _resourceManager = Properties.Resources.ResourceManager;

        public static void SetLanguage(string culture)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting language: {ex.Message}");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
        }

        public static string GetString(string key)
        {
            string result = _resourceManager.GetString(key);
            return result ?? $"Key '{key}' not found in resources";
        }
    }
}
