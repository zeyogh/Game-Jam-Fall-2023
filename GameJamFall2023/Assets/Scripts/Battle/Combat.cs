using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    private enum State
    {
        ENEMY_TURN,
        PLAYER_SELECT_MOVE,
        PLAYER_TURN,
        FINISHED
    }

    private State state;

    private bool switched;

    public ProgressBar allyBar;

    public ProgressBar enemyBar;

    public Character[] allies = new Character[4];

    private Character activeCharacter;

    private int selectedMove;

    private int activeCharIndex;

    private int targetCharIndex;

    private int enemyLoop;

    private bool combatEnded;

    private Character targetedCharacter;

    private Character[] targetList;

    public Enemy[] enemies;

    public Menu menu;

    private void Start()
    {
        state = State.PLAYER_SELECT_MOVE;
        activeCharacter = allies[0];
        switched = false;
        enemyLoop = 0;
    }

    private void Update()
    {
        //When player is picking a move and target
        if (state == State.PLAYER_SELECT_MOVE)
        {
            if (!switched)
            {
                switched = true;
                menu.showCharacterTurn(activeCharacter, 0);
                targetedCharacter = allies[0];
                targetedCharacter.toggleReticle(true);
                targetList = allies;
                targetCharIndex = 0;
                selectedMove = 0;
            }

            //choose move
            if (Input.GetKeyDown("right"))
            {
                menu.showCharacterTurn(activeCharacter, 1);
                selectedMove = 1;
            }
            if (Input.GetKeyDown("left"))
            {
                menu.showCharacterTurn(activeCharacter, 0);
                selectedMove = 0;
            }

            //choose character
            if (Input.GetKeyDown("w"))
            {
                if (targetedCharacter == targetList[0])
                {
                    return;
                }
                targetedCharacter.toggleReticle(false);
                targetedCharacter = targetList[--targetCharIndex];
                targetedCharacter.toggleReticle(true);
            }
            if (Input.GetKeyDown("s"))
            {
                if (targetedCharacter == targetList[targetList.Length - 1])
                {
                    return;
                }
                targetedCharacter.toggleReticle(false);
                targetedCharacter = targetList[++targetCharIndex];
                targetedCharacter.toggleReticle(true);
            }

            //toggle if targeting allies or enemies
            if (Input.GetKeyDown("a"))
            {
                if (targetList == allies)
                {
                    return;
                }
                targetList = allies;
                targetedCharacter.toggleReticle(false);
                targetedCharacter = allies[0];
                targetedCharacter.toggleReticle(true);
                targetCharIndex = 0;
            }
            if (Input.GetKeyDown("d"))
            {
                if (targetList == enemies)
                {
                    return;
                }
                targetList = enemies;
                targetedCharacter.toggleReticle(false);
                targetedCharacter = enemies[0];
                targetedCharacter.toggleReticle(true);
                targetCharIndex = 0;
            }

            if (Input.GetKeyDown("return"))
            {
                if (selectedMove == 0)
                {
                    combatEnded = activeCharacter.attackBasic(targetedCharacter);
                    menu.showUsingMove(activeCharacter.attacks[0].name, activeCharacter.attacks[0].description);
                }
                else
                {
                    combatEnded = activeCharacter.attackSpecial(targetedCharacter);
                    menu.showUsingMove(activeCharacter.attacks[1].name, activeCharacter.attacks[1].description);
                }
                targetedCharacter.toggleReticle(false);
                switched = false;
                state = State.PLAYER_TURN;
            }
        }

        //Player cutscene
        else if (state == State.PLAYER_TURN)
        {
            if (!switched)
            {
                switched = true;
                activeCharacter.moveCharacter();
            }

            if (activeCharacter.finishedMoving)
            {
                if (combatEnded)
                {
                    state = State.FINISHED;
                    if (gameObject.scene.name.Equals("Battle3"))
                    {
                        SceneManager.LoadScene("Final Boss");
                        return;
                    }
                    InfoHolder info = FindObjectOfType<InfoHolder>();
                    info.nextRoom();
                    SceneManager.LoadScene(info.currentRoom);
                    return;
                }
                switched = false;
                activeCharacter.finishedMoving = false;
                state = State.ENEMY_TURN;
                toggleActiveCharacter();
            }

        }

        //Enemy cutscene
        else if (state == State.ENEMY_TURN)
        {
            if (!switched)
            {
                switched = true;
                menu.showUsingMove(enemies[enemyLoop].attacks[0].name, enemies[enemyLoop].attacks[0].description);
                enemies[enemyLoop].attack();
            }

            if (enemies[enemyLoop].finishedMoving)
            {
                if (combatEnded)
                {
                    state = State.FINISHED;
                    SceneManager.LoadScene("GameOver");
                    return;
                }
                enemyLoop++;
                switched = false;
                if (enemyLoop == enemies.Length)
                {
                    enemyLoop = 0;
                    state = State.PLAYER_SELECT_MOVE;
                }
                enemies[enemyLoop].finishedMoving = false;
            }


        }
    }

    private void toggleActiveCharacter()
    {
        activeCharIndex =  (activeCharIndex == allies.Length - 1) ? 0 : activeCharIndex++;
    }

    private void updatePlayerProgress()
    {

    }

    private void updateEnemyProgress()
    {

    }


}
