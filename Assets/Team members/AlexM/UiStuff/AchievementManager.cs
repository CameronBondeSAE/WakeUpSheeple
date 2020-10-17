using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AlexM
{
	public class AchievementManager : MonoBehaviour
	{
		/// <summary>
		/// PLEASE NOTE: This is all purely for testing the concept and to get feedback during class/when possible on if this is the
		/// right direction to go in the first place.
		/// Launch the achievementTestScene, hit up arrow really fast to get above the jumpAchievementThreshold
		/// </summary>
		public float achievementShowTimer;
		public TestGuyStuff testGuy;
		public List<GameObject> GOStoToggle;
		public TextMeshProUGUI _title, _text;

		private float jumpTimer;
		private int jumpAchievementThreshold = 5;

		private void OnEnable()
		{
			//ToggleGameObjects();
			testGuy.jumpEvent += TestGuyOnjumpEvent;
		}

		private void TestGuyOnjumpEvent(GameObject obj, int jumpCount)
		{
			if (jumpCount > 5)
			{
				Debug.Log("YOU GOT OVER 5, YAY!");
				TriggerAchievement("Jump King", "You got lots of jumps!");
				return;
			}
		}



		public void TriggerAchievement(string title, string text)
		{
			//TODO:Make it so that they first enable/show the text for a set time, then disable it, but it seems to be doing things a bit differently than i expected.
			//StartCoroutine(showAchievementFor(achievementShowTimer, "Jump King", "You got lots of jumps!"));
			_title.SetText(title);
			_text.SetText(text);
		}

		IEnumerator showAchievementFor(float time, string title, string text)
		{
			ToggleGameObjects();
			// _title.SetText(title);
			// _text.SetText(text);
			yield return new WaitForSeconds(time);
			ToggleGameObjects();
		}

	#region EditorUiStuff

		//This region is just dedicated to the button i've added in the editor for this script. will add relevant fields in their correct positions.

		public TextMeshProUGUI title_prefab, text_prefab;

		public void QuickSetup()
		{
			//TODO: Fix the anchor stuff, messes with postioning for some reason..
			var title = Instantiate(title_prefab, this.transform, false);
			var text = Instantiate(text_prefab, this.transform, false);
			_title = title;
			_text = text;
			// title.rectTransform.anchorMin = new Vector2(0.5f, 1);
			// title.rectTransform.anchorMax = new Vector2(0.5f, 1);
			
			var titleX = title.rectTransform.position.x;
			var titleY = title.rectTransform.position.y;
			titleX = 0;
			titleY = 85;
			
		}

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

	#endregion
	}

}