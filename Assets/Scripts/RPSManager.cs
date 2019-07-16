using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSManager : MonoBehaviour
{

    private Text userChoice;
    private Text resultText;

    private string[] options = new string[3] { "piedra", "papel", "tijeras" };

    public void GameProcess()
    {
        userChoice = GameObject.FindGameObjectWithTag("UserInput").GetComponent<Text>();
        resultText = GameObject.FindGameObjectWithTag("Result").GetComponent<Text>();

        bool validWord = false;

        for (int i = 0; i < options.Length; i++)
        {
            if (userChoice.text.ToString().Equals(options[i]))
                validWord = true;
        }

        if (!validWord)
        {
            resultText.text = "Palabra inválida";
            return;
        }

        string opponentsChoice = options[Random.Range(0, 3)];
        int result = getVictoryIndex(userChoice.text.ToString(), opponentsChoice);

        if (result > 0)
        {
            resultText.text = (opponentsChoice + "\nGanaste");
        }
        else if (result < 0)
        {
            resultText.text = (opponentsChoice + "\nPerdiste");
        }
        else if (result == 0)
        {
            resultText.text = (opponentsChoice + "\nEmpate");
        }

    }

    static int getVictoryIndex(string s, string opponent)
    {

        switch (s)
        {
            case "piedra":
                if (opponent == "piedra")
                    return 0;
                else if (opponent == "tijeras")
                    return 1;
                else if (opponent == "papel")
                    return -1;
                break;
            case "tijeras":
                if (opponent == "piedra")
                    return -1;
                else if (opponent == "tijeras")
                    return 0;
                else if (opponent == "papel")
                    return 1;
                break;
            case "papel":
                if (opponent == "piedra")
                    return 1;
                else if (opponent == "tijeras")
                    return -1;
                else if (opponent == "papel")
                    return 0;
                break;
            default:
                return 0;
        }

        return 0;
    }
}
