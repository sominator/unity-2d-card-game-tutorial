using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public UIManager UIManager;
    public int TurnOrder = 0;
    public string GameState = "Initialize {}";
    public int PlayerBP = 0;
    public int OpponentBP = 0;
    public int PlayerVariables = 0;
    public int OpponentVariables = 0;

    private int ReadyClicks = 0;

    void Start()
    {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        UIManager.UpdatePlayerText();
        UIManager.UpdateButtonText(GameState);
    }

    public void ChangeGameState(string stateRequest)
    {
        if (stateRequest == "Initialize {}")
        {
            ReadyClicks = 0;
            GameState = "Initialize {}";
        }
        else if (stateRequest == "Compile {}")
        {
            if (ReadyClicks == 1)
            {
                GameState = "Compile {}";
                UIManager.HighlightTurn(TurnOrder);
            }
        }
        else if (stateRequest == "Execute {}")
        {
            GameState = "Execute {}";
            TurnOrder = 0;
        }
        UIManager.UpdateButtonText(GameState);
    }

    public void ChangeReadyClicks()
    {
        ReadyClicks++;
    }

    public void CardPlayed()
    {
        TurnOrder++;
        UIManager.HighlightTurn(TurnOrder);
        if (TurnOrder == 10)
        {
            ChangeGameState("Execute {}");
        }
    }

    public void ChangeBP (int playerBP, int opponentBP, bool hasAuthority)
    {
        if (hasAuthority)
        {
            PlayerBP += playerBP;
            OpponentBP -= opponentBP;
        }
        else
        {
            PlayerBP -= opponentBP;
            OpponentBP += playerBP;
        }
        UIManager.UpdatePlayerText();
    }

    public void ChangeVariables (int variables, bool hasAuthority)
    {
        if (hasAuthority)
        {
            PlayerVariables += variables;
        }
        else
        {
            OpponentVariables += variables;
        }
        UIManager.UpdatePlayerText();
    }
}
