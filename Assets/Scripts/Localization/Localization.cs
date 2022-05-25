using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public enum Locale
{
    en,
    pt
}



/// <summary>
/// session 7
/// static class
/// all members HAVE TO be static
/// </summary>
public static class Localization
{

    private static Dictionary<Locale, Dictionary<string, string>> s_localizationTable;

    public static Locale s_currentLocale = Locale.en;

    // variable declaration, a => b means update a as b changes 
    public static Dictionary<string, string> s_currentLocalizationTable => s_localizationTable[s_currentLocale];



    // constructor, will be executed by the editor (VS)
    static Localization()
    {
        Load();
    }



    private static void Load()
    {
        // loading a text file
        var source = Resources.Load<TextAsset>("LocalizationSource");

        // characters ALWAYS IN SINGLE QUOTES
        // rows separated by new lines
        // cols separated by ;
        // split for every new line in our CSV source
        var lines = source.text.Split('\n');
        var header = lines[0].Split(';'); // ["", "en", "pt"]

        var localeOrder = new List<Locale>(header.Length - 1);

        // setting a blank dictionary, to be populated by for loops
        s_localizationTable = new Dictionary<Locale, Dictionary<string, string>>();

        // 
        for (int i = 1; i < header.Length; i++)
        {
            var locale = (Locale)Enum.Parse(typeof(Locale), header[i]);
            localeOrder.Add(locale);
            s_localizationTable[locale] = new Dictionary<string, string>(lines.Length - 1);
        } // for

        // creating key value pairs
        for (int index = 1; index < lines.Length; index++)
        {
            // entry will be the row
            var entry = lines[index].Split(';');
            var key = entry[0]; // event -> first column

            // array.Lenght
            // List.Count

            // looping through languages (locale orders)
            for (var j = 0; j < localeOrder.Count; j++)
            {
                var locale = localeOrder[j]; // en / pt
                // table[en][0]
                s_localizationTable[locale][key] = entry[j + 1]; // hi , ola
            }
        }

    } // Load


}
