using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public ProgressBar allyBar;

    public ProgressBar enemyBar;

    public Character[] allies = new Character[4];

    public Enemy[] enemies;

    public Menu menu;

    public Combat(Enemy[] enemySet)
    {
        enemies = enemySet;
    }


}
