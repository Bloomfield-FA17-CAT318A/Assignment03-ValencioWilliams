using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
	public static PlayerBlock instance;

	public static PlayerBlock Instance
	{
		get
		{ 
			if (instance == null)
				instance = GameObject.FindObjectOfType<PlayerBlock> ();

			return instance;
		}
	}



	public Panel panel1, panel2, panel3;

	public int currentPanel = 0;

	void Start ()
	{
		transform.position = panel2.panelLoc.position;
	}

	void Update ()
	{
		Inputs ();
		BlockMove ();
	}

	void Inputs ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow) && currentPanel > -1)
		{
			currentPanel--;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && currentPanel < 1)
		{
			currentPanel++;
		}
	}

	void BlockMove ()
	{
		if (currentPanel == panel1.id)
		{
			transform.position = panel1.panelLoc.position;
		}

		if (currentPanel == panel2.id)
		{
			transform.position = panel2.panelLoc.position;
		}

		if (currentPanel == panel3.id)
		{
			transform.position = panel3.panelLoc.position;
		}
	}


}