﻿//using UnityEditor;
//using UnityEngine;

//namespace LightGive
//{
//	[CustomPropertyDrawer(typeof(AudioClipInfoAttribute))]
//	public class AudioClipInfoDrawer : PropertyDrawer
//	{
//		public Texture PlayOffIconTexture { get { return EditorGUIUtility.FindTexture("d_preAudioPlayOff"); } }
//		public Texture PlayOnIconTexture { get { return EditorGUIUtility.FindTexture("d_preAudioPlayOn"); } }
//		public Texture LoopOffIconTexture { get { return EditorGUIUtility.FindTexture("d_preAudioLoopOff"); } }
//		public Texture LoopOnIconTexture { get { return EditorGUIUtility.FindTexture("d_preAudioLoopOn"); } }

//		/// <summary>
//		/// 描画処理
//		/// </summary>
//		/// <param name="position">表示範囲</param>
//		/// <param name="property">プロパティ</param>
//		/// <param name="label">ラベル</param>
//		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//		{
//			AudioClipInfoAttribute att = (AudioClipInfoAttribute)attribute;
//			using (new EditorGUI.PropertyScope(position, label, property))
//			{
//				var halfWid = EditorGUIUtility.currentViewWidth / 2.0f;
//				var quarterWid = EditorGUIUtility.currentViewWidth / 4.0f;
//				var oneEighthWid = EditorGUIUtility.currentViewWidth / 8.0f;

//				//オーディオの名前を表示する範囲
//				var audioNoRect = new Rect(position)
//				{
//					width = quarterWid
//				};
//				//オーディオクリップを表示する範囲
//				var audioClipRect = new Rect(position)
//				{
//					x = oneEighthWid + 15,
//					width = quarterWid * 1.5f
//				};
//				//AudioClipの時間を表示する範囲
//				var audioTimeRect = new Rect(position)
//				{
//					x = oneEighthWid + (quarterWid * 1.5f) + 15
//				};

//				//使うかのボタンを表示する範囲
//				var audioEnableButtonRect = new Rect(position)
//				{
//					x = position.width - oneEighthWid - oneEighthWid,
//					width = oneEighthWid
//				};


//				var audioTextLoopRect = new Rect(position)
//				{
//					x = position.width - (oneEighthWid / 1.5f) - (oneEighthWid / 1.5f) + 20,
//					width = (oneEighthWid / 1.5f)
//				};

//				var audioTestPlayRect = new Rect(position)
//				{
//					x = position.width - (oneEighthWid / 1.5f) + 22,
//					width = (oneEighthWid / 1.5f)
//				};

//				var audioNoProp = property.FindPropertyRelative("audioNo");
//				var isUseProp = property.FindPropertyRelative("isUse");
//				var clipProp = property.FindPropertyRelative("clip");

//				if (clipProp.objectReferenceValue == null)
//				{
//					EditorGUI.LabelField(position, "Missing");
//				}
//				else
//				{
//					var clip = (AudioClip)clipProp.objectReferenceValue;
//					var t = (clip).length;

//					if (!AudioUtility.IsClipPlaying(clip) && att.playPropPath == property.propertyPath)
//					{
//						if (att.loopList.Contains(property.propertyPath))
//						{
//							AudioUtility.PlayClip((AudioClip)clipProp.objectReferenceValue);
//						}
//						else
//						{
//							att.playPropPath = "";
//						}
//					}

//					EditorGUI.LabelField(audioNoRect, audioNoProp.intValue.ToString("00") + ".");
//					EditorGUI.BeginDisabledGroup(true);
//					{
//						EditorGUI.ObjectField(audioClipRect, "", clipProp.objectReferenceValue, typeof(AudioClip), false);
//					}
//					EditorGUI.EndDisabledGroup();
//					EditorGUI.LabelField(audioTimeRect, Mathf.FloorToInt(t / 60.0f).ToString("00") + ":" + (t % 60).ToString("00"));

//					EditorGUI.BeginChangeCheck();
//					var toggle = GUI.Toggle(audioTextLoopRect, att.loopList.Contains(property.propertyPath), LoopOffIconTexture, GUI.skin.button);
//					if (EditorGUI.EndChangeCheck())
//					{
//						if (toggle)
//						{
//							att.loopList.Add(property.propertyPath);
//						}
//						else
//						{
//							att.loopList.Remove(property.propertyPath);
//						}
//					}

//					var isPlaying = (att.playPropPath == property.propertyPath);
//					var tex = isPlaying ? PlayOnIconTexture : PlayOffIconTexture;
//					if (GUI.Button(audioTestPlayRect, tex))
//					{
//						if (isPlaying)
//						{
//							AudioUtility.StopClip((AudioClip)clipProp.objectReferenceValue);
//							att.playPropPath = "";
//						}
//						else
//						{
//							AudioUtility.StopAllClips();
//							AudioUtility.PlayClip((AudioClip)clipProp.objectReferenceValue);
//							att.playPropPath = property.propertyPath;
//						}
//					}
//				}
//			}
//		}


//	}
//}