using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockyRoad : MonoBehaviour
{
	public static bool isitActive = false;

	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Escape) && !isitActive)
		{
			isitActive = true;
			MenuManager.GoToMenu(MenuName.Pause);
			
		}
	}
}
