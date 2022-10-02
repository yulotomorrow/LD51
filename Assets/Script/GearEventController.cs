using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class GearEvent : UnityEvent<bool>
{
}

public class GearEventController : MonoBehaviour
{
	public static GearEvent onGearTurn;
	public GameObject pn;
	void Awake()
	{
		if (onGearTurn == null)
			onGearTurn = new GearEvent();
	}

	public void PlusDir() 
	{
		onGearTurn.Invoke(true);
	}
	public void MinusDir()
	{
		onGearTurn.Invoke(false);
	}
	public void CloseWindow() 
	{
		pn.SetActive(false);
	}

}
