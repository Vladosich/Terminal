using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen {Menu, Game, Win};
    Screen currentScreen = Screen.Menu;
    private string password;
    private readonly string[] level1Passwords = { "котик", "лягушка", "собака" };
    private readonly string[] level2Passwords = { "Лукашенко", "Зеленский", "Янукович", "Путин"};
    private readonly string[] level3Passwords = { "наливай", "шампанского", "давай вино"};
    void Start()
    {
        ShowMenu();
    }
    void ShowMenu()
    {
        currentScreen = Screen.Menu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Ку чел, выбери уровень\n" +
            "1 - Поджатый\n" +
            "2 - Мистер чел\n" +
            "3 - Крепкий подпивас ");
    }
    
    void OnUserInput(string input)
    {
        if (currentScreen == Screen.Menu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Game)
        {
            CheckPassword(input);
        }
        else
        {
            if(input == "меню")
            {
                ShowMenu();
            }
        }
    }
    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                Terminal.ClearScreen();
                password = level1Passwords[Random.Range(0,level1Passwords.Length)];
                Terminal.WriteLine("Поджатый? Мда... Ну ладно");
                GameStart();
                break;
            case "2":
                Terminal.ClearScreen();
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                Terminal.WriteLine("Оу, Мистер Чел, гуд ивнинг");
                GameStart();
                break;
            case "3":
                Terminal.ClearScreen();
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                Terminal.WriteLine("Ёмаё, какие люди\n" +
                    "Вам как обычно 5л жигулевского?");
                GameStart();
                break;
            default:
                Terminal.WriteLine("Ты туповат? Введи 1, 2 или 3");
                break;
        }
    }
    void GameStart()
    {
        currentScreen = Screen.Game;
        Terminal.WriteLine("Расшифруйте - " + password.Anagram());
        Terminal.WriteLine("Напишите 'меню' чтобы вернуться к выбору уровня");
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else if(input == "меню")
        {
            ShowMenu();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Попробуй еще раз...");
            GameStart();
        }
    }
    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        switch (password)
        {
            case "котик":
                Terminal.WriteLine(@"
 _._     _,-'""`-._
(,-.`._,'(       |\`-/|
    `-.-' \ )-`( , o o)
          `-    \`_`''-
");
                break;
            case "лягушка":
                Terminal.WriteLine(@"
            _     _
           (')-=-(')
         __(   ''  )__
       / _/ '-----'\_ \
    ___\\ \\       // //___
   >____)/ _\ --- /_\(____ <
    ");
                break;
            case "собака":
                Terminal.WriteLine(@"
       _=,_
    o_/6 /#\
    \__ |##/
     ='|--\
       /   #'-.
       \#|_   _'-. /
        |/ \_( # | '
       C / , --___ /
");
                break;
            case "Лукашенко":
                Terminal.WriteLine("Идет мужик по улице с работы, трезвый, никого не трогает.\n" +
                    "Вдруг рядом тормозит автозак, вылетают омоновцы и начинают паковать его в машину, " +
                    "лупят дубинками. Мужик кричит:\n" +
                    "— Отпустите, я за Лукашенко голосовал!\n" +
                    "— Врешь, за него никто не голосовал!\n" +
                    " ");
                break;
            case "Зеленский":
            case "Путин":
                Terminal.WriteLine("Позвонив Путину Зеленский твердо потребовал вернуть Крым,\n" +
                    "Донбасс и триллион долларов репараций. И это ВВП еще не взял трубку...\n" +
                    " ");
                break;
            case "Янукович":
                Terminal.WriteLine("После того, как Янукович пообещал:\n" +
                    "— Я БУДУ ТАМ, ГДЕ ДОЛЖЕН БЫТЬ!, \n" +
                    "остается только гадать в какой именно тюрьме окажется Виктор Фёдорыч...\n" +
                    " ");
                break;
            case"наливай":
                Terminal.WriteLine(@"
         . .
       .. . *.
- -_ _-__-0oOo
 _-_ -__ -||||)
    ______||||______
~~~~~~~~~~`'''

");
                break;
            case "давай вино":
                Terminal.WriteLine(@"
    _____
   /.---.\
   |`````|
   \     /
    `-.-'           ____
      |    /\     .'   /\
    __|__  |K----;    |  |
   `-----` \/     '.___\/
");
                break;
            case "шампанского":
                Terminal.WriteLine(@"
 . .
\~~~~~/
 \   /
  \ /
   V
   |
   |
  ---
");
                break;

        }
        Terminal.WriteLine("Правильно!");
        Terminal.WriteLine("Напишите 'меню' чтобы вернутьсяк выбору уровня");
    }
}
