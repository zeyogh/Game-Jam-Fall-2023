using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : MonoBehaviour
{
    public RoomPlayerMovement player;

    public float dist;

    bool focused = false;

    public bool isHP;

    InfoHolder info;

    bool switched = false;

    public string key;

    private void Start()
    {
        info = FindObjectOfType<InfoHolder>();
    }

    private void Update()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        float distance = Mathf.Sqrt(((x - playerX) * (x - playerX)) + ((y - playerY) * (y - playerY)));

        if (distance <= dist)
        {
            if (!focused)
            {
                switched = true;
            }
            else
            {
                switched = false;
            }
            focused = true;
        }
        else
        {
            if (focused)
            {
                switched = true;
            }
            else
            {
                switched = false;
            }
            focused = false;
        }

        if (focused)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown("return"))
            {
                updateVal();
            }
        }
        else if (!focused)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void updateVal()
    {
        if (isHP)
        {
            info.HP -= 3;
            return;
        }
        info.SP += 1;
    }
}
