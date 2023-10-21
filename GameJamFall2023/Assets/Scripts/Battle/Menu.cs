using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject EnemyMove;

    public GameObject CharacterMove;

    public GameObject CharacterTurn;

    public GameObject targetSelection;

    /*
     * Standard prompts
     */
    private string targetting = "The hot wind is blowing..."; //While the player is selecting a target

    private string usingMove = " is using:\n"; //When an ally or enemy does something

    private string[] selectMoveType = { "Basic [X]\tSpecial [ ]", "Basic [ ]\tSpecial [X]" };

    

}
