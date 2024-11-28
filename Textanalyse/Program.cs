using System;

namespace Textanalyse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //teil 1
            string text = "Der Campus Wilhelminenhof liegt an derWilheminenhofstraße 75 in 12459 Berlin.";
            int ausgabe = ZaehleZahlen(text);
            Console.WriteLine($"Anzahl der Zahlen im Text: {ausgabe}");

            //teil 2
            char haeufigsterBuchstabe = ErmittleHaeufigstenBuchstaben(text);
            int anzahl = ErmittleAnzahl(text);

            //Tupeltypen (wär schöner)
            //https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/value-tuples
            //(char haeufigsterBuchstabe, int anzahl) = ErmittleHaeufigstenBuchstaben(text);
            Console.WriteLine($"Der Häufigste Buchstabe = {haeufigsterBuchstabe} ist: {anzahl}");

        }
        //Methode prüft die anzahl der Zahlen
        public static int ZaehleZahlen(string s)
        {
            int zaehler = 0;
            bool inNumber = false;

            foreach (char z in s) //prüft nacheinander jedes zeichen in s
            {
                //prüft ob char eine Zahl ist
                if (char.IsDigit(z))
                {
                    if (!inNumber) //wenn wir uns noch nicht bereits in einer zahl davor befinden rechne 1+
                    {
                        zaehler++;
                        inNumber = true;
                    }
                }
                else //ändere inNumber weder auf false
                {
                    inNumber = false;
                }
            }
            return zaehler;
        }

        //schöner wär
        //public static (char, int) ErmittleHaeufigstenBuchstaben(string s)
        public static char ErmittleHaeufigstenBuchstaben(string s)
        {
            //array zur speicherung der häufigkeit jedes zeichens (nach ascii-wert)
            //https://learn.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/arrays
            int[] haeufigkeit = new int[255];

            foreach (char z in s)
            {
                //Prüft ob der char ein Buchstabe ist
                if (char.IsLetter(z))
                {
                    //Konvertiert den Buchstaben in seinen ASCII-Wert
                    int ascii = (int)z;
                    //Erhöht die Häufigkeit des Buchstabens
                    haeufigkeit[ascii]++;
                }
            }

            int maxHaeufigkeit = 0;
            char haeufigsterBuchstabe ='\0'; //Null wert

            for (int i = 0; i < haeufigkeit.Length; i++)
            {
                // Überprüft, ob die aktuelle Häufigkeit größer ist als die bisher höchste Häufigkeit
                if (haeufigkeit[i] > maxHaeufigkeit)
                {
                    //Aktualisiert die höchste Häufigkeit
                    maxHaeufigkeit = haeufigkeit[i];
                    // Setzt den häufigsten Buchstaben auf den aktuellen Buchstaben (ASCII-Wert wird in char umgewandelt)
                    haeufigsterBuchstabe = (char)i;
                }
            }
            return haeufigsterBuchstabe;
            //return (haeufigsterBuchstabe, maxHaeufigkeit); //Tupel
        }

        //neue Methode... da man Tupel nicht nutzen darf -.-
        public static int ErmittleAnzahl(string s)
        {
            int[] haeufigkeit = new int[255];

            foreach (char z in s)
            {
                if (char.IsLetter(z))
                {
                    int ascii = (int)z;
                    haeufigkeit[ascii]++;
                }
            }

            int maxHaeufigkeit = 0;
            char haeufigsterBuchstabe = '\0'; //Null wert

            for (int i = 0; i < haeufigkeit.Length; i++)
            {
                if (haeufigkeit[i] > maxHaeufigkeit)
                {
                    maxHaeufigkeit = haeufigkeit[i];
                    haeufigsterBuchstabe = (char)i;
                }
            }
            return maxHaeufigkeit;
        }
    }
}
