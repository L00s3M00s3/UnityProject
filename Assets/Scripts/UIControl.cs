using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
	public Canvas PauseCanvas, HelpCanvas, CreditCanvas;

	private bool isPaused;
	public bool sceneStarting;
	//public GameObject Fader;

	public AudioClip ButtonPress;
    void Start()
    {
        Time.timeScale = 1;
    }

	void Update()
	{

		/*if (sceneStarting) {
			Fader.GetComponent<Animator> ().SetTrigger ("LevelStart");
		
		}*/ 

		//Pause Canvas not working, pls fix
		//pause game if Escape is pressed
		if(Input.GetKeyDown(KeyCode.Escape))
		{

			if (!isPaused) {
				PauseCanvas.GetComponent<Canvas>().enabled = true;
				isPaused = true;
				//freeze game
				Time.timeScale = 0;
			}
		

			else { //if gameis paused, and escape is pressed again, close pause menu

				PauseCanvas.GetComponent<Canvas>().enabled = false;
				//unfreeze
				Time.timeScale = 1;
				isPaused = false;
			

			}
		}

	
	
	}


	public void LoadGame()
	{
		AudioSource.PlayClipAtPoint (ButtonPress, Camera.main.transform.position);
		SceneManager.LoadScene ("Level1");

	}
	public void OpenMainMenu()
	{
		AudioSource.PlayClipAtPoint (ButtonPress, Camera.main.transform.position);
		SceneManager.LoadScene ("MainMenu");
	}


	public void OpenHelp()
	{
		//AudioSource.PlayClipAtPoint (ButtonPress, Camera.main.transform.position);
		HelpCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void CloseHelp()
	{
		
		HelpCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void OpenCredits()
	{
		//AudioSource.PlayClipAtPoint (ButtonPress, Camera.main.transform.position);
		CreditCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void CloseCredits(){
		
	
		CreditCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void ExitGame()
	{
		AudioSource.PlayClipAtPoint (ButtonPress, Camera.main.transform.position);
		Application.Quit();
	}

	public void PlayButtonSound()
	{
		AudioSource.PlayClipAtPoint (ButtonPress, Camera.main.transform.position);

	}
}
