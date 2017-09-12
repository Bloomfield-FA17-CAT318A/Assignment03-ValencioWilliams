using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public enum EnemySpeed
	{
		SLOW,
		MEDIUM,
		FAST
	};

	public EnemySpeed setting = EnemySpeed.SLOW;

	#region Singleton

	public static GameController Instance
	{
		get
		{ 
			if (instance == null)
			{
				instance = FindObjectOfType<GameController> ();
			}

			return instance;
		}
	}

	private static GameController instance;

	#endregion


	#region Variables

	public int score = 0;

	public Panel[] panels;

	public EnemyBlock block;

	public Text scoreText;

	public Canvas pauseScreen;

	public float spawnrate = 0.7f;

	public int gamePause = 0;

	private float timer = 0f;

	#endregion

	void Start ()
	{
		pauseScreen.enabled = false;

		InvokeRepeating ("SpawnBlocks", 2f, spawnrate);
	}

	void Update ()
	{
		switch (setting)
		{
		case EnemySpeed.SLOW:
			{
				block.moveSpeed = 15;
			}
			break;

		case EnemySpeed.MEDIUM:
			{
				block.moveSpeed = 25;
			}
			break;

		case EnemySpeed.FAST:
			{
				block.moveSpeed = 50;
			}
			break;
		}

		if (setting == EnemySpeed.SLOW && timer > 10f)
		{
			setting = EnemySpeed.MEDIUM;
		}

		if (setting == EnemySpeed.MEDIUM && timer > 15f)
		{
			setting = EnemySpeed.FAST;
		}

		timer += Time.deltaTime;

	}

	void SpawnBlocks ()
	{
		int rand = Random.Range (0, panels.Length);

		EnemyBlock tmp = (EnemyBlock)Instantiate (block, panels [rand].panelLoc.position, Quaternion.identity);

		tmp.mat.material.color = panels [rand].GetComponent<MeshRenderer> ().material.color;
	}

	public void NewGame ()
	{
		score = 0;
		gamePause = 0;
		setting = EnemySpeed.SLOW;
		DeleteSave ();
	}

	public void SaveGame ()
	{
		PlayerPrefs.SetInt ("score", score);
	}

	public void LoadGame ()
	{
		score = PlayerPrefs.GetInt ("score");
		scoreText.text = "Score: " + score;

	}

	public void Pausegame ()
	{
		if (Time.timeScale != 0)
		{
			Time.timeScale = 0;
			pauseScreen.enabled = true;

		} else
		{
			Time.timeScale = 1;
			pauseScreen.enabled = false;

		}
	}

	public void DeleteSave ()
	{
		PlayerPrefs.DeleteKey ("score");
		//PlayerPrefs.DeleteKey ("pause");

	}

	
}


