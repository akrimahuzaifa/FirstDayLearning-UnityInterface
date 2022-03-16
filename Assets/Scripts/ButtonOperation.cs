using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOperation : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
