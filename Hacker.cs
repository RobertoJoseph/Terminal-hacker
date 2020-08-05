
using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
      int level;
    string[] Level1Pass = { "ladder", "human", "tools","gloves","helmet" };
    string[] Level2Pass = { "glasses", "eye", "pen","ruler","papers","dish","mobilephone" };
    string[] Level3Pass = { "spaceship", "rocket", "moon","ozonlayer","blackhole"};
    const string MenuHint = " Type menu to return back to levels";
       enum Screen { MainMenu , Password , Win}
    Screen currentScreen;
    string password;
   

    // Start is called before the first frame update
    void Start()
    {
        showMenu();
      

    }
    void showMenu()
        
    {
        
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello Bahbk");
        Terminal.WriteLine("Press 1 to climb!");
        Terminal.WriteLine("Press 2 to read!");
        Terminal.WriteLine("Press 3 to go NASA!");


    }
    void OnUserInput(string input) // el method de 3azema fash5 , kol ma dos enter btgddlk l input ya gams fash5
    {
        if (input == "menu") 
        {
            showMenu();

        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
       
    }

  void RunMainMenu(string input)
    {
        bool IsCorrect = (input == "1" || input == "2"||input=="3");
        if (IsCorrect)
        {
            level = int.Parse(input);
            AskForPassword();

        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please Select James Bond Level");
        }
        else
        {
            Terminal.WriteLine("Please Select Valid Level");
            Terminal.WriteLine(MenuHint);
        }
    }

    void AskForPassword()

    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPass();
        Terminal.WriteLine("Solve this puzzle, [hint]: " + password.Anagram());
        Terminal.WriteLine(MenuHint);
    }

    void SetRandomPass()
    {
        switch (level)
        {
            case 1:
                password = Level1Pass[UnityEngine.Random.Range(0, Level1Pass.Length)];
                break;
            case 2:
                password = Level2Pass[UnityEngine.Random.Range(0, Level2Pass.Length)];
                break;
            case 3:
                password = Level3Pass[UnityEngine.Random.Range(0, Level3Pass.Length)];
                break;

            default:
                Debug.Log("Invalid level number");
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
        ShowReward();
        Terminal.WriteLine(MenuHint);

    }

    void ShowReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Get this ladder to climb!");
                Terminal.WriteLine("YOU DID IT");
                Terminal.WriteLine(@"
╬═╬
╬═╬ 
╬═╬
╬═╬");            break;

            case 2:
                Terminal.WriteLine("Get this Book!");
                Terminal.WriteLine("NICE ONE YA BRO");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/       
"); break;
            case 3:
                
                Terminal.WriteLine(@"  
| \ | | / _ \ /  ___|/ _ \ 
|  \| |/ /_\ \\ `--./ /_\ \
| . ` ||  _  | `--. \  _  |
| |\  || | | |/\__/ / | | |
\_| \_/\_| |_/\____/\_| |_/
                           ");
                Terminal.WriteLine("WELCOME TO NASA INTERNATIONAL");
                break;
               
            default:
                Terminal.WriteLine("FASHEL");
                break;

        }
    }





    // Update is called once per frame
    void Update()
    {
      
        
    }
}
