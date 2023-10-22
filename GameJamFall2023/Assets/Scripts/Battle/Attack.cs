using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Character character;

    public enum Type
    {
        BASIC,
        SPECIAL
    }

    public enum Class
    {
        FILL, //"DPS" role that fills progress bar
        HEAL, //Heals debuffed allies
        BUFF, //Buffs allies
        DEBUFF //Lowers enemy's ability to fill bar
    }

    public Class moveClass;

    public Type type;

    public int points;

    public new string name = "Some Attack";

    public string description = "Lazy ass description";

    public Attack(Type type, int points)
    {
        this.type = type;
        this.points = points;
    }

    public bool activate()
    {
        bool done = character.progressBar.add(character.specialVal);
        return done;
    }


    public bool activate(Character ch)
    {
        if (moveClass == Class.HEAL)
        {
            ch.specialVal = ch.specialValBase;
        }
        else if (moveClass == Class.DEBUFF)
        {
            ch.specialVal -= ch.specialValBase / 10;
        }
        else if (moveClass == Class.BUFF)
        {
            ch.specialVal += ch.specialValBase / 10;
        }
        else
        {
            bool done = activate();
            return done;
        }
    }
}
