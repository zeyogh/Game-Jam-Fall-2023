using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Character character;

    public enum Class
    {
        FILL, //"DPS" role that fills progress bar
        HEAL, //Heals debuffed allies
        BUFF, //Buffs allies
        DEBUFF, //Lowers enemy's ability to fill bar
        BASIC //Slightly fills progress bar and recovers skill point
    }

    public Class moveClass;

    public int points;

    public new string name = "Some Attack";

    public string description = "Lazy ass description";

    public bool activate()
    {
        bool done = character.progressBar.add(character.specialVal);
        return done;
    }


    public bool activate(Character ch)
    {
        SkillPoints sp = character.sp;

        if (moveClass == Class.HEAL)
        {
            ch.specialVal = ch.specialValBase;
            sp.toggle(character.specialCost, true);
        }
        else if (moveClass == Class.DEBUFF)
        {
            ch.specialVal -= ch.specialValBase / 10;
            sp.toggle(character.specialCost, true);
        }
        else if (moveClass == Class.BUFF)
        {
            ch.specialVal += ch.specialValBase / 10;
            sp.toggle(character.specialCost, true);
        }
        else if (moveClass == Class.FILL)
        {
            bool done = activate();
            sp.toggle(character.specialCost, true);
            return done;
        }
        else
        {
            sp.toggle(false);
        }
        return false;
    }
}
