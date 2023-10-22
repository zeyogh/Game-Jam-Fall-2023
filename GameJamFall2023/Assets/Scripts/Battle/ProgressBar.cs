using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public int max;

    public int current;

    public bool add(int val)
    {
        current += val;
        this.GetComponentInChildren<TMP_Text>().text = Mathf.Min(current, max) + "/" + max;
        return current >= max;
    }
}
