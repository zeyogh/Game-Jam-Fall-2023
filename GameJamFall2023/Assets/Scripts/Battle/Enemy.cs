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
            this.attackBasic(target);
            this.moveCharacter();
            return;
        }

        int decider = Random.Range(0, 2);
        if (decider == 0)
        {
            this.attackBasic(target);
            this.moveCharacter();
        }
        else
        {
            this.attackSpecial(target);
            this.moveCharacter();
        }
        
    }

}
