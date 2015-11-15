using UnityEngine;
using System.Collections;


/// <summary>
/// Ablility class.
/// intened fire the "onCast" event when off cooldown,
/// the cooldown is impimented. Call cast when spell  is to be fired.
/// </summary>
public abstract class Ablility 
{
	public float coolDown =2f;
	private bool ready = true;
	private float nextReady = - 250;//so the spell will be ready when the game starts

	protected abstract void onCast(); //suceeded cast effect

	protected void cast()//try to cast
	{
		checkReady();
		if(ready)
		{
			onCast();
			nextReady = Time.time + coolDown;
		}

	}

	private void checkReady()
	{
		if(nextReady <= Time.time)//if we are past the point in time the spell is ready
		{
			ready = true;
		}
	}
}
