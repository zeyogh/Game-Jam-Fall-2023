using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoints : MonoBehaviour
{
    public SkillPoint[] allPoints = new SkillPoint[10]; //note that originally only 5 points

    int indexOfLastPoint;

    void Start()
    {
        if (allPoints.Length > 10) //definitely bugged don't add more than 10
        {
            indexOfLastPoint = 10;
            foreach (SkillPoint ex in allPoints)
            {
                ex.gameObject.SetActive(true);
            }
            return;
        }

        for (int i = 0; i < allPoints.Length; i++)
        {
            allPoints[i].gameObject.SetActive(true);
        }
        indexOfLastPoint = allPoints.Length - 1;
        
    }

    public void toggle(bool remove)
    {
        if (remove && indexOfLastPoint >= 0)
        {
            allPoints[indexOfLastPoint].gameObject.SetActive(false);
            indexOfLastPoint--;
        }
        else if (!remove && indexOfLastPoint < 9)
        {
            indexOfLastPoint++;
            allPoints[indexOfLastPoint].gameObject.SetActive(true);
        }
    }

    public void toggle(int points, bool remove)
    {
        for (int i = 0; i < points; i++)
        {
            toggle(remove);
        }
        
    }

    public int getCurrentPoints()
    {
        return indexOfLastPoint - 1;
    }

}
