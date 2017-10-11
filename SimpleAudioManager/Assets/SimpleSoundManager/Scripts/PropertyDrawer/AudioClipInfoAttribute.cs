﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioClipInfoAttribute : PropertyAttribute
{
	[SerializeField]
	public bool isRoute;

	public bool isLoop;

	public AudioClipInfoAttribute()
	{

	}
}
