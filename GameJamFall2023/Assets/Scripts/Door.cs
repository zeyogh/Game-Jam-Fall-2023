using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public RoomPlayerMovement player;

    public float dist;

    public string battle;

    bool focused = false;

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
                if (Input.GetKeyDown("return"))
                {
                    enter();
                }
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
        }
        else if (!focused)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void enter()
    {
        InfoHolder info = FindObjectOfType<InfoHolder>();
        info.currentRoom = gameObject.scene.name;
        SceneManager.LoadScene(battle);
    }
}
