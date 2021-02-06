using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.SceneManagement;

public class ButtonSceneSwitcher : MonoBehaviour {
    private Controller con;

    void Start()
    {
        con = new Controller(2759);
    }

	public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void OnApplicationQuit()
    {
        con.StopConnection();
    }
}
