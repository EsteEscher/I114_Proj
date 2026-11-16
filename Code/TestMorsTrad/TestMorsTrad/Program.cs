///ETML
///Auteur           : Esteban Escher
///Date             : 16.11.2026
///1 : le code Mors est un encodage
///2 : Afin de la rendre lisible sur des supports différents

//Variable
string userInput;
int userIntput;
char userSingleput;
bool validator = true;
int verif;
string translated = "";
string value = "";
string decorti = "";
Dictionary<char, String> morse = new Dictionary<char, String>()
    {
        {'A' , ".-"},
        {'B' , "-..."},
        {'C' , "-.-."},
        {'D' , "-.."},
        {'E' , "."},
        {'F' , "..-."},
        {'G' , "--."},
        {'H' , "...."},
        {'I' , ".."},
        {'J' , ".---"},
        {'K' , "-.-"},
        {'L' , ".-.."},
        {'M' , "--"},
        {'N' , "-."},
        {'O' , "---"},
        {'P' , ".--."},
        {'Q' , "--.-"},
        {'R' , ".-."},
        {'S' , "..."},
        {'T' , "-"},
        {'U' , "..-"},
        {'V' , "...-"},
        {'W' , ".--"},
        {'X' , "-..-"},
        {'Y' , "-.--"},
        {'Z' , "--.."},
        {'a' , ".-"},
        {'b' , "-..."},
        {'c' , "-.-."},
        {'d' , "-.."},
        {'e' , "."},
        {'f' , "..-."},
        {'g' , "--."},
        {'h' , "...."},
        {'i' , ".."},
        {'j' , ".---"},
        {'k' , "-.-"},
        {'l' , ".-.."},
        {'m' , "--"},
        {'n' , "-."},
        {'o' , "---"},
        {'p' , ".--."},
        {'q' , "--.-"},
        {'r' , ".-."},
        {'s' , "..."},
        {'t' , "-"},
        {'u' , "..-"},
        {'v' , "...-"},
        {'w' , ".--"},
        {'x' , "-..-"},
        {'y' , "-.--"},
        {'z' , "--.."},
        {'0' , "-----"},
        {'1' , ".----"},
        {'2' , "..---"},
        {'3' , "...--"},
        {'4' , "....-"},
        {'5' , "....."},
        {'6' , "-...."},
        {'7' , "--..."},
        {'8' , "---.."},
        {'9' , "----."},
        {' ', " / " },
    };

Dictionary<string, String> texte = new Dictionary<string, String>()
    {
        { ".-", "A" },
        { "-...", "B" },
        { "-.-.", "C" },
        { "-..", "D" },
        { ".", "E" },
        { "..-.", "F" },
        { "--.", "G" },
        { "....", "H" },
        { "..", "I" },
        { ".---", "J" },
        { "-.-", "K" },
        { ".-..", "L" },
        { "--", "M" },
        { "-.", "N" },
        { "---", "O" },
        { ".--.", "P" },
        { "--.-", "Q" },
        { ".-.", "R" },
        { "...", "S" },
        { "-", "T" },
        { "..-", "U" },
        { "...-", "V" },
        { ".--", "W" },
        { "-..-", "X" },
        { "-.--", "Y" },
        { "--..", "Z" },
        { "-----", "0" },
        { ".----", "1" },
        { "..---", "2" },
        { "...--", "3" },
        { "....-", "4" },
        { ".....", "5" },
        { "-....", "6" },
        { "--...", "7" },
        { "---..", "8" },
        { "----.", "9" }
    };

do
{
    Console.Clear();
    //Menu
    Console.WriteLine("=== Couteau Suisse ===");
    Console.WriteLine("1. Texte -> Morse");
    Console.WriteLine("2. Morse -> Texte");
    Console.WriteLine("3. à venir");
    Console.WriteLine("4. à venir");
    Console.WriteLine("0. Quitter");
    do
    {
        Console.Write("\nUser Input : ");
        userInput = Console.ReadLine();

        verif = 1;

        if (!int.TryParse(userInput, out userIntput))
        {
            Console.WriteLine("Seules les chiffres valides sont autorisé pour le choix");
            validator = false;
            verif = 0;
        }
        if (userIntput > 4 || userIntput < 0)
        {
            Console.WriteLine("Seules les chiffres valides sont autorisé pour le choix");
            validator = false;
            verif = 0;
        }
        if (verif == 1)
            validator = true;


    } while (validator == false);

    switch (userIntput)
    {
        case 1:
            {
                Console.WriteLine(" === Texte -> Morse ===\nTexte (lettre A-Z, chiffres)  : ");
                validator = false;
                while (validator == false)
                {
                    userInput = Console.ReadLine();
                    for (int i = 0; i < userInput.Length; i++)
                    {
                        morse.TryGetValue(userInput[i], out value);
                        if (value != null)
                            validator = true;
                        else
                        {
                            Console.WriteLine("Entrée non valide");
                            continue;
                        }

                    }
                    if (validator == true)
                        translated = convertTextToMors(userInput);
                }
                Console.WriteLine("\nAppuyer sur y pour quitter et tout autre touche pour continuer.");
                userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y")
                {
                    validator = true;
                }
                else
                {
                    validator = false;
                }
                break;
            }
        case 2:
            {
                Console.WriteLine(" === Morse -> Texte ===\nMorse (. - espace /)  : ");
                validator = false;
                while (validator == false)
                {
                    userInput = Console.ReadLine();
                    for (int i = 0; i < userInput.Length; i++)
                    {
                        decorti = "";
                        if (userInput[i] == '/')
                        {
                            translated += (" ");
                            i++;
                        }
                        while (i < userInput.Length && userInput[i] != '/' && userInput[i] != ' ')
                        {
                            decorti += userInput[i];
                            i++;
                        }
                        texte.TryGetValue(decorti, out value);
                        if (value != null)
                            validator = true;
                        else
                        {
                            Console.WriteLine("Entrée non valide");
                            continue;
                        }

                    }
                    if (validator == true)
                        translated = convertMorsToText(userInput);
                }
                Console.WriteLine("\nAppuyer sur y pour quitter et tout autre touche pour continuer.");
                userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y")
                {
                    validator = true;
                }
                else
                {
                    validator = false;
                }
                break;
            }
        case 0:
            {
                validator = false;
                break;
            }
        default:
            {
                break;
            }

    }
}while (validator == false);

 string convertTextToMors(string userInput)
{
    string value = "";
    string translated = "";
    string trans = "";
    
    for (int i = 0; i < userInput.Length; i++)
    {
        morse.TryGetValue(userInput[i], out value);
        translated += value;
        translated += " ";
    }
    Console.WriteLine("Résultat en Morse :\n" + translated);
    return translated;
}
string convertMorsToText(string userInput)
{
    string value = "";
    string translated = "";
    string decorti = "";
    
    for (int i = 0; i < userInput.Length; i++)
    {
        decorti = "";
        if (userInput[i] == '/')
        {
            translated += (" ");
            i++;
        }
        while(i < userInput.Length && userInput[i] != '/' && userInput[i] != ' ')
        {
            decorti += userInput[i];
            i++;
        }
        texte.TryGetValue(decorti, out value);
        translated += value;
    }
    Console.WriteLine("Résultat en Texte :\n" + translated);

    return translated;
}
