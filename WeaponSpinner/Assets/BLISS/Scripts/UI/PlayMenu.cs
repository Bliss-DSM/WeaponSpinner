using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : Menu<PlayMenu>
{
	public Button buttonPause;
	public Button buttonAttack;
	public Button buttonDash;
	public Joystick joystick;

	protected override void Awake()
	{
		base.Awake();
		buttonPause.onClick.AddListener(() => { PauseMenu.Open();});
	}
}
