using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public void Level(int Level)
    {
        SceneManager.LoadScene(Level);
    }
}
