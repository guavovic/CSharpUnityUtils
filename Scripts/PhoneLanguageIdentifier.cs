using UnityEngine;

namespace GV.Extensions
{
    public enum Languages
    {
        English,
        Portuguese
    }

    public static class ApplicationLanguageIdentifier
    {
        private void Start()
        {
            LanguageIdentifier();
        }

        public static string GetApplicationLanguage()
        {
            return Application.systemLanguage.ToString();
        }

        private void LanguageIdentifier()
        {
            if (PlayerPrefs.HasKey("Idioma"))
                return;

            string currentLanguage = GetApplicationLanguage();
            CheckCurrentLanguage(currentLanguage);
            print($"The native language of the device is: {currentLanguage}");
        }

        private void CheckCurrentLanguage(string currentLanguage)
        {
            if (System.Enum.TryParse(currentLanguage, out Languages parsedLanguage))
            {
                Texts.ChangeLanguage(parsedLanguage);
            }
            else
            {
                // O padrão é inglês se o idioma não for suportado
                Texts.ChangeLanguage(Languages.English);
            }
        }
    }

    public static class Texts
    {
        public static void ChangeLanguage(Languages language)
        {
            Debug.Log($"Language changed to: {language}");
        }
    }
}
