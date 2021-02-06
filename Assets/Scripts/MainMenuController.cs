using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public bool isStart, isQuit;

	void OnMouseUp()
    {
        if (isStart) SceneManager.LoadScene("_Scenes/Flight", LoadSceneMode.Single);
        if (isQuit) Application.Quit();
    }
}
