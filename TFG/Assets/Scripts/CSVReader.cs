using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CSVReader  {


    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    //Idiomas
    public const string ESPAÑOL = "Español";
    public const string ENGLISH = "English";
    public string currentLanguage = ESPAÑOL;

    //Diccionario general
    private Dictionary<string, Dictionary<string, string>> dic_general  = new Dictionary<string, Dictionary<string, string>>();

    public static CSVReader instance = null;
    public static CSVReader Instance {
        get
        {
            if (instance == null)
            {
                instance = new CSVReader();
            }
            return instance;
        }
    }
    

    private CSVReader() { }

    public Dictionary<string,Dictionary<string, string>> Read(string file)
    {
        
        TextAsset data = Resources.Load(file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return dic_general;

        var header = Regex.Split(lines[0], SPLIT_RE);

        //Creamos un diccionario por idioma y añadimos al diccionario de idiomas
        for(var i = 1; i<header.Length; i++)
        {
            Dictionary<string, string> language = new Dictionary<string, string>();
            dic_general.Add(header[i], language);
        }
                    
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            for (var j = 1; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                //guardamos el id con el valor correspondiente a cada idioma
                getLanguage(header[j]).Add(values[0], value);          
                
            }
        }
        return dic_general;
    }

    public  Dictionary<string,string> getLanguage(String language)
    {
        return dic_general[language];
    }

    public void changeLanguage(String language)
    {
        currentLanguage = language;
    }

    

}
