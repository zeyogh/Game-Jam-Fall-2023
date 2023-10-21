using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Character character;

    public enum Type
    {
        FILL, //"DPS" role that fills progress bar
        HEAL, //Heals debuffed allies
        BUFF, //Buffs allies
        DEBUFF //Lowers enemy's ability to fill bar
    }

    public Type type;

    public int points;

    public Attack(Type type, int points)
    {
        this.type = type;
        this.points = points;
    }

    public void activate()
    {
        character.progressBar.add(character.specialVal);
    }


    public void activate(Character ch)
    {
        if (type == Type.HEAL)
        {
            ch.specialVal = ch.specialValBase;
        }
        else if (type == Type.DEBUFF)
        {
            ch.specialVal -= ch.specialValBase / 10;
        }
        else if (type == Type.BUFF)
        {
            ch.specialVal += ch.specialValBase / 10;
        }
    }
}
