﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAudioSetting : MonoBehaviour, 
	IBeginDragHandler,
	IDragHandler, 
	IEndDragHandler,
	IPointerEnterHandler, 
	IPointerExitHandler
{
	private UnityEvent eventBeginDrag;
	private UnityEvent eventDrag;
	private UnityEvent eventEndDrag;
	private UnityEvent eventPointerEnter;
	private UnityEvent eventPointerExit;


	public AudioNameSE m_EnterAudioName;
	public AudioNameSE m_ExitAudioName;
	public AudioNameSE m_ClickAudioName;
	
	void Awake()
	{
		var b = this.gameObject.GetComponent<Button>();
		if (!b) { return; }

		
		b.onClick.AddListener(OnPointerEnter);

	}


	void OnPointerEnter()
	{
		//AudioManager.Instance.PlaySound2D(audioNameSE.ToString());
	}

	void Start()
	{

	}

	void Update()
	{

	}

	public void OnBeginDrag(PointerEventData ped)
	{
		if (eventBeginDrag != null)
			eventBeginDrag.Invoke();
	}
	public void OnDrag(PointerEventData ped)
	{
		if (eventDrag != null)
			eventDrag.Invoke();
	}
	public void OnEndDrag(PointerEventData ped)
	{
		if (eventEndDrag != null)
			eventEndDrag.Invoke();
	}
	public void OnPointerEnter(PointerEventData ped)
	{
		if (eventPointerEnter != null)
			eventPointerEnter.Invoke();
	}
	public void OnPointerExit(PointerEventData ped)
	{
		if (eventPointerExit != null)
			eventPointerExit.Invoke();
	}
}
