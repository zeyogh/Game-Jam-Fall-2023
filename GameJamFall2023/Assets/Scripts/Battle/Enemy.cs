using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public bool isBoss;

    public Team team;

    public void attack()
    {
        int availableSkillPoints = team.currentPoints;
        Character target = team.combat.allies[Random.Range(0, 4)];

        if (this.specialCost > availableSkillPoints)
        {
            Debug.Log("Basic 1");
            this.attackBasic(target);
            this.moveCharacter();
            return;
        }

        int decider = Random.Range(0, 2);
        if (decider == 0)
        {
            Debug.Log("Basic 2");
            this.attackBasic(target);
            this.moveCharacter();
        }
        else
        {
            Debug.Log("You are my Specialz");
            this.attackSpecial(target);
            this.moveCharacter();
        }
        
    }

}
