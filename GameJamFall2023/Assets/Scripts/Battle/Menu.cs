using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject EnemyMove;

    public GameObject CharacterMove;

    public GameObject CharacterTurn;

    public GameObject targetSelection;

    /*
     * Standard prompts
     */
    private string targeting = "The hot wind is blowing..."; //While the player is selecting a target

    private string usingMove = " is using:\n"; //When an ally or enemy does something

    private string[] selectMoveType = { "Basic [X]\tSpecial [ ]", "Basic [ ]\tSpecial [X]" };

    public void showUsingMove(string name, string move)
    {
        EnemyMove.SetActive(false);
        targetSelection.SetActive(false);
        CharacterTurn.SetActive(false);
        CharacterMove.SetActive(true);
        CharacterMove.GetComponentInChildren<TMP_Text>().text = name + usingMove + move;
    }

    public void showCharacterTurn(Character ch, int i)
    {
        EnemyMove.SetActive(false);
        targetSelection.SetActive(false);
        CharacterMove.SetActive(false);
        CharacterTurn.SetActive(true);
        CharacterTurn.GetComponentInChildren<TMP_Text>().text = selectMoveType[i];
    }

    public void showTargeting()
    {
        EnemyMove.SetActive(false);
        CharacterMove.SetActive(false);
        CharacterTurn.SetActive(false);
        targetSelection.SetActive(true);
    }

}
