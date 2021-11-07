using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen {Menu, Game, Win};
    Screen currentScreen = Screen.Menu;
    private string password;
    private readonly string[] level1Passwords = { "�����", "�������", "������" };
    private readonly string[] level2Passwords = { "���������", "���������", "��������", "�����"};
    private readonly string[] level3Passwords = { "�������", "�����������", "����� ����"};
    void Start()
    {
        ShowMenu();
    }
    void ShowMenu()
    {
        currentScreen = Screen.Menu;
        Terminal.ClearScreen();
        Terminal.WriteLine("�� ���, ������ �������\n" +
            "1 - ��������\n" +
            "2 - ������ ���\n" +
            "3 - ������� �������� ");
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
            if(input == "����")
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
                Terminal.WriteLine("��������? ���... �� �����");
                GameStart();
                break;
            case "2":
                Terminal.ClearScreen();
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                Terminal.WriteLine("��, ������ ���, ��� ������");
                GameStart();
                break;
            case "3":
                Terminal.ClearScreen();
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                Terminal.WriteLine("���, ����� ����\n" +
                    "��� ��� ������ 5� ������������?");
                GameStart();
                break;
            default:
                Terminal.WriteLine("�� �������? ����� 1, 2 ��� 3");
                break;
        }
    }
    void GameStart()
    {
        currentScreen = Screen.Game;
        Terminal.WriteLine("����������� - " + password.Anagram());
        Terminal.WriteLine("�������� '����' ����� ��������� � ������ ������");
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else if(input == "����")
        {
            ShowMenu();
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("�������� ��� ���...");
            GameStart();
        }
    }
    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        switch (password)
        {
            case "�����":
                Terminal.WriteLine(@"
 _._     _,-'""`-._
(,-.`._,'(       |\`-/|
    `-.-' \ )-`( , o o)
          `-    \`_`''-
");
                break;
            case "�������":
                Terminal.WriteLine(@"
            _     _
           (')-=-(')
         __(   ''  )__
       / _/ '-----'\_ \
    ___\\ \\       // //___
   >____)/ _\ --- /_\(____ <
    ");
                break;
            case "������":
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
            case "���������":
                Terminal.WriteLine("���� ����� �� ����� � ������, �������, ������ �� �������.\n" +
                    "����� ����� �������� �������, �������� �������� � �������� �������� ��� � ������, " +
                    "����� ���������. ����� ������:\n" +
                    "� ���������, � �� ��������� ���������!\n" +
                    "� �����, �� ���� ����� �� ���������!\n" +
                    " ");
                break;
            case "���������":
            case "�����":
                Terminal.WriteLine("�������� ������ ��������� ������ ���������� ������� ����,\n" +
                    "������� � �������� �������� ���������. � ��� ��� ��� �� ���� ������...\n" +
                    " ");
                break;
            case "��������":
                Terminal.WriteLine("����� ����, ��� �������� ��������:\n" +
                    "� � ���� ���, ��� ������ ����!, \n" +
                    "�������� ������ ������ � ����� ������ ������ �������� ������ Ը�����...\n" +
                    " ");
                break;
            case"�������":
                Terminal.WriteLine(@"
         . .
       .. . *.
- -_ _-__-0oOo
 _-_ -__ -||||)
    ______||||______
~~~~~~~~~~`'''

");
                break;
            case "����� ����":
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
            case "�����������":
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
        Terminal.WriteLine("���������!");
        Terminal.WriteLine("�������� '����' ����� ���������� ������ ������");
    }
}
