using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AlexM
{
	public class AchievementManager : MonoBehaviour
	{
		/// <summary>
		/// THIS SHOULD ALWAYS BE ON A CANVAS.
		/// PLEASE NOTE:
		/// You only need to add the TestGuy from the scene, and set a duration for how long the achievement popup is visible.
		///
		/// To add new achievements, just subscribe to their event (please make the event with plenty of into attached)
		/// And just call TriggerAchievement("Title", "SubText") inside the function created when subscribing to the event.
		/// </summary>
		[Header("Settings")]
		[Tooltip("How long the Achievement will show for when triggered.")]
		public float visibleDuration = 5;


		[Header("Achievement Variables")]
		public TestGuyStuff testGuy;

		private float jumpTimer;
		private int jumpAchievementThreshold = 5;

		//General

		[HideInInspector]
		public List<GameObject> GOStoToggle;

		[HideInInspector]
		public TextMeshProUGUI _title, _text;

		private void OnEnable()
		{
			title_prefab = Resources.Load<TextMeshProUGUI>("AchievementManager/TXT_AchievementTitle");
			text_prefab = Resources.Load<TextMeshProUGUI>("AchievementManager/TXT_AchievementText");
			SetGOListState(false);

			if (testGuy)
			{
				testGuy.jumpEvent += TestGuyOnjumpEvent;
			}
		}

	#region Achievements Go Here!

		private void TestGuyOnjumpEvent(GameObject obj, int jumpCount)
		{
			if (jumpCount > 5)
			{
				//Debug.Log("YOU GOT OVER 5, YAY!");
				TriggerAchievement("Jump King", "You got lots of jumps!");
			}
		}


		public void TriggerAchievement(string title, string text)
		{
			StartCoroutine(durationToShow(visibleDuration, title, text));
		}

		IEnumerator durationToShow(float time, string title, string text)
		{
			SetGOListState(true);
			_title.SetText(title);
			_text.SetText(text);
			yield return new WaitForSeconds(time);
			SetGOListState(false);
		}

	#endregion

	#region EditorUiStuff

		//This region is just dedicated to the button i've added in the editor for this script. will add relevant fields in their correct positions.
		[HideInInspector]
		public TextMeshProUGUI title_prefab, text_prefab;

		public void QuickSetup()
		{
			title_prefab = Resources.Load<TextMeshProUGUI>("AchievementManager/TXT_AchievementTitle");
			text_prefab = Resources.Load<TextMeshProUGUI>("AchievementManager/TXT_AchievementText");


			if (!_title)
			{
				_title = Instantiate(title_prefab, this.transform, false);
			}

			if (!_text)
			{
				_text = Instantiate(text_prefab, this.transform, false);
			}

			GOStoToggle = new List<GameObject>();
			GOStoToggle.Add(_title.gameObject);
			GOStoToggle.Add(_text.gameObject);


			//TODO: Fix the anchor stuff, messes with postioning for some reason..
			//_title.rectTransform.anchorMin = new Vector2(0.5f, 1);
			//_title.rectTransform.anchorMax = new Vector2(0.5f, 1);


			var titleX = _title.rectTransform.position.x;
			var titleY = _title.rectTransform.position.y;
			titleX = 0;
			titleY = 85;
		}

	#region Game Objects To Toggle Stuff

		/// <summary>
		/// If either of these two functions are having issues then its because the GOSToToggle list isnt populating properly.
		/// Make the List public and figure out what the issues is there.
		/// OR the quick setup is broken for some reason.
		/// </summary>
		public void ToggleGameObjects()
		{
			foreach (var GO in GOStoToggle)
			{
				if (GO.activeSelf)
				{
					GO.SetActive(false);
				}
				else
				{
					GO.SetActive(true);
				}
			}
		}

		public void SetGOListState(bool state)
		{
			foreach (var GO in GOStoToggle)
			{
				GO.SetActive(state);
			}
		}

	#endregion

	#endregion
	}
}