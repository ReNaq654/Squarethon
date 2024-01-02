using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
