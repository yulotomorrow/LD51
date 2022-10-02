using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void quitGame()
	{
		Application.Quit();
	}

	public void GotoStart()
	{
		SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
	}

	public void StartGame()
	{
		SceneManager.LoadScene("PlotScene", LoadSceneMode.Single);
	}

	public void QuitGame() 
	{
		Application.Quit();
	}
}
