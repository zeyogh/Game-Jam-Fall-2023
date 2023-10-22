using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToRoom : MonoBehaviour
{
    public void returnToRoom()
    {
        InfoHolder info = FindObjectOfType<InfoHolder>();
        SceneManager.LoadScene(info.currentRoom);
    }
}
