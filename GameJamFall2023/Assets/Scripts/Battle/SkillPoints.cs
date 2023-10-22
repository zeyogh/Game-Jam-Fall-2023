using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoints : MonoBehaviour
{
    public SkillPoint[] allPoints = new SkillPoint[10]; //note that originally only 5 points

    int indexOfLastPoint;

    public SkillPoints(int points)
    {
        if (points > 9)
        {
            indexOfLastPoint = 9;
            foreach (SkillPoint ex in allPoints)
            {
                ex.gameObject.SetActive(true);
            }
            return;
        }

        for (int i = 0; i < points; i++)
        {
            allPoints[i].gameObject.SetActive(true);
        }
        
    }

    public void toggle(bool remove)
    {
        if (remove && indexOfLastPoint >= 0)
        {
            allPoints[indexOfLastPoint].gameObject.SetActive(false);
            indexOfLastPoint--;
        }
        else if (indexOfLastPoint < 9)
        {
            indexOfLastPoint++;
            allPoints[indexOfLastPoint].gameObject.SetActive(true);
        }
    }

    public int getCurrentPoints()
    {
        return indexOfLastPoint - 1;
    }

}
