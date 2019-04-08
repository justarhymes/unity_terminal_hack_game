using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "post", "reblog", "like", "yahoo", "notes", "follow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "cornfield", "democracy", "presidential", "collusion", "mueller" };
    // Game state
    int level;
    string password;
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("What up, Narc!");
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What we hacking??");
        Terminal.WriteLine("1: Hack Tumblr!");
        Terminal.WriteLine("2: Hack the police!!");
        Terminal.WriteLine("3: Hack the president!!1!");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if ( input.ToLower() == "menu")
        {
            ShowMainMenu("Let's try this again.");
        }
        else if ( currentScreen == Screen.MainMenu )
        {
            RunMainMenu(input);
        }
        else if ( currentScreen == Screen.Password )
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input.ToLower() == "fuck you")
        {
            Terminal.WriteLine("Wow, that was really mean...");
        }
        else if (input == "666")
        {
            Terminal.WriteLine("HAIL SATAN!");
        }
        else
        {
            Terminal.WriteLine("Choose a valid number, Champ.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();   
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Woops, that was too easy, Hacker.");
                Terminal.WriteLine(@"
       .o
      .88
    o8888oo
    ''888''
      888
      888.
      '888Y
                ");
                break;
            case 2:
                Terminal.WriteLine("You're going to jail, Hacker.");
                Terminal.WriteLine(@"
    _*_ ....iiooiioo
 __/_|_\__ 
[(o)_R_(o)]        fe
                ");
                break;
            case 3:
                Terminal.WriteLine("Welcome to the President of the");
                Terminal.WriteLine(@"
 _   _ ___  __ _ 
| | | / __|/ _` |
| |_| \__ \ (_| |
 \__,_|___/\__,_|
                ");
                Terminal.WriteLine("You are now on a watch list, Hacker.");
                break;
            default:
                Debug.LogError("Invalid level completed.");
                break;
        }
        Terminal.WriteLine(menuHint);
    }
}
