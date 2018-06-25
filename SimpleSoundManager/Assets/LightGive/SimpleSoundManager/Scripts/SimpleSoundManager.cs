﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SimpleSoundManager : SingletonMonoBehaviour<SimpleSoundManager>
{
	[SerializeField]
	public List<AudioClip> audioClipListSe = new List<AudioClip>();
	[SerializeField]
	public List<AudioClip> audioClipListBgm = new List<AudioClip>();

	[SerializeField]
	private List<SoundEffectPlayer> m_soundEffectPlayers = new List<SoundEffectPlayer>();
	[SerializeField]
	private int m_sePlayerNum = 10;

	private Dictionary<string, AudioClip> m_audioClipDictSe = new Dictionary<string, AudioClip>();
	private Dictionary<string, AudioClip> m_audioClipDirtBgm = new Dictionary<string, AudioClip>();


	protected override void Init()
	{
		base.Init();
		for (int i = 0; i < m_sePlayerNum;i++)
		{
			GameObject soundPlayerObj = new GameObject("SoundPlayer" + i.ToString("0"));
			soundPlayerObj.transform.SetParent(transform);
			SoundEffectPlayer player = soundPlayerObj.AddComponent<SoundEffectPlayer>();
			player.Init();
			m_soundEffectPlayers.Add(player);
		}

		//Dictionaryに追加
		for (int i = 0; i < audioClipListSe.Count;i++)
		{
			m_audioClipDictSe.Add(audioClipListSe[i].name, audioClipListSe[i]);
		}
		for (int i = 0; i < audioClipListBgm.Count; i++)
		{
			m_audioClipDirtBgm.Add(audioClipListBgm[i].name, audioClipListBgm[i]);
		}
	}

	public void PlaySE(string _audioName)
	{
		if (!m_audioClipDictSe.ContainsKey(_audioName))
		{
			Debug.Log("その名前のSEは見つかりませんでした。");
			return;
		}

		var player = GetSoundEffectPlayer();
		var clip = m_audioClipDictSe[_audioName];
		player.Play(clip);
	}


	private SoundEffectPlayer GetSoundEffectPlayer()
	{
		for (int i = 0; i < m_soundEffectPlayers.Count;i++)
		{
			if (m_soundEffectPlayers[i].isActive)
				continue;

			return m_soundEffectPlayers[i];
		}

		int idx = 0;
		for (int i = 1; i < m_soundEffectPlayers.Count; i++)
		{
			if (m_soundEffectPlayers[i].Length > m_soundEffectPlayers[idx].Length)
			{
				idx = i;
			}
		}
		return m_soundEffectPlayers[idx];
	}
}
