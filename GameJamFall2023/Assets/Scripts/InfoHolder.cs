using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHolder : MonoBehaviour
{
    public int HP = 99;
    public int SP = 5;
    public string currentRoom = "Room";

    public void nextRoom()
    {
        if (currentRoom.Equals("Room"))
        {
            currentRoom = "Room2";
        }
        else
        {
            currentRoom = "Room3";
        }
    }
}
