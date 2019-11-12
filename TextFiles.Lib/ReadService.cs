﻿using System;
using System.IO;
using Microsoft.Win32;
using System.Text;


namespace TextFiles.Lib
{
    public class ReadService
    {
        public static string RootPad { get; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string MyDocs { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public string TextFileToString(string bestandsMap, string bestandsNaam, Encoding encoding = null)
        {
            string bestandsInhoud = "";
            string bestandsPad = bestandsMap + "\\" + bestandsNaam;

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            if (string.IsNullOrEmpty(bestandsPad.Trim()))
            {
                throw new Exception("Er is geen bestand gekozen");
            }
            if (!Directory.Exists(bestandsMap))
            {
                throw new Exception("De map is niet gevonden");
            }
            if (!File.Exists(bestandsPad))
            {
                throw new Exception("Het bestand is niet gevonden");
            }

            try
            {
                // Er wordt een instance aangemaakt van de StreamReader-class
                using (StreamReader sr = new StreamReader(bestandsPad, encoding))
                {
                    bestandsInhoud = sr.ReadToEnd();
                }
                // na het using statement wordt de StreamReader gesloten en wordt het geheugen vrijgegeven.
            }
            catch (IOException)
            {
                throw new IOException($"Het bestand {bestandsPad} kan niet geopend worden.\nProbeer het te sluiten.");
            }
            catch (Exception e)
            {
                throw new Exception($"Er is een fout opgetreden. {e.Message}");
            }

            return bestandsInhoud;
        }

    }
}
