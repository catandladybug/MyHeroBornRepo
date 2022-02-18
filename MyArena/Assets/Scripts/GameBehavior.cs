using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{

	public bool showWinScreen = false;
	public bool showLossScreen = false;

	public string labelText = "Capture the enemy's flag to win!";
	public int maxItems = 3;

	private int _itemsCollected = 0;

	public GameObject bas;
	private BlueBaseBehavior bool_script;

	public GameObject ebas;
	private OrangeBaseBehavior bool_scriptt;

	private int _playerHP = 10;

	private void Start()
	{

		bool_script = bas.GetComponent<BlueBaseBehavior>();

		bool_scriptt = ebas.GetComponent<OrangeBaseBehavior>();

	}
	private void Update()
	{
		if (bool_script.scorePoint == true) 
		{
			showWinScreen = true;
		}

		if (bool_scriptt.escorePoint == true)
		{
			showLossScreen = true;
		}
	}

	public int HP
	{
		get { return _playerHP; }

		set
		{
			_playerHP = value;

			if (_playerHP <= 0)
			{

				labelText = "You want another life with that?";
				showLossScreen = true;
				Time.timeScale = 0;
			}
			else
			{

				labelText = "Ouch... that's got to hurt.";
			}
		}
	}
	void RestartLevel()
	{

		SceneManager.LoadScene(0);
		Time.timeScale = 1.0f;

	}

	void OnGUI()
	{
		GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
		//GUI.Box(new Rect(20, 50, 150, 25), "Flags Collected: " + _itemsCollected);
		GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

		if (showWinScreen)
		{

			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
			{

				RestartLevel();

			}
		}

			if (showLossScreen)
			{

				if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lost...")) 
				{

					RestartLevel();

				}

			}
	}
}