using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.BehaviourTrees{

	[Name("Filter")]
	[Category("Decorators")]
	[Description("Filters the access of it's child node either a specific number of times, or every specific amount of time. By default the node is 'Treated as Inactive' to it's parent when child is Filtered. Unchecking this option will instead return Failure when Filtered.")]
	[Icon("Lock")]
	public class Filter : BTDecorator {

		public enum FilterMode
		{
			LimitNumberOfTimes,
			CoolDown
		}

		public FilterMode filterMode = FilterMode.CoolDown;
		public BBParameter<int> maxCount = new BBParameter<int>{value = 1};
		public BBParameter<float> coolDownTime = new BBParameter<float>{value = 5};
		public bool inactiveWhenLimited = true;

		private int executedCount;
		private float currentTime;

		public override void OnGraphStarted(){
			executedCount = 0;
			currentTime = 0;
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard){

			if (decoratedConnection == null)
				return Status.Resting;

			switch(filterMode)
            {
                case FilterMode.CoolDown:

			        if (currentTime > 0)
			            return inactiveWhenLimited? Status.Resting : Status.Failure;

			        status = decoratedConnection.Execute(agent, blackboard);
			        if (status == Status.Success || status == Status.Failure)
			            StartCoroutine(Cooldown());
			        break;
			    
                case FilterMode.LimitNumberOfTimes:

			        if (executedCount >= maxCount.value)
			            return inactiveWhenLimited? Status.Resting : Status.Failure;

			        status = decoratedConnection.Execute(agent, blackboard);
			        if (status == Status.Success || status == Status.Failure)
			            executedCount += 1;
			        break;
			}

			return status;
		}


		IEnumerator Cooldown(){

			currentTime = coolDownTime.value;
			while (currentTime > 0){
				yield return null;
				currentTime -= Time.deltaTime;
			}
		}

		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR
		
		protected override void OnNodeGUI(){

			if (filterMode == FilterMode.CoolDown){
				GUILayout.Space(25);
				var pRect = new Rect(5, GUILayoutUtility.GetLastRect().y, nodeRect.width - 10, 20);
				UnityEditor.EditorGUI.ProgressBar(pRect, currentTime/coolDownTime.value, currentTime > 0? "Cooling..." : "Cooled");
			}
			else
			if (filterMode == FilterMode.LimitNumberOfTimes){
				GUILayout.Label(executedCount + " / " + maxCount.value + " Accessed Times");
			}
		}

		protected override void OnNodeInspectorGUI(){

			filterMode = (FilterMode)UnityEditor.EditorGUILayout.EnumPopup("Mode", filterMode);

			if (filterMode == FilterMode.CoolDown){
				coolDownTime = (BBParameter<float>)EditorUtils.BBParameterField("CoolDown Time", coolDownTime);
			}
			else
			if (filterMode == FilterMode.LimitNumberOfTimes){
				maxCount = (BBParameter<int>)EditorUtils.BBParameterField("Max Times", maxCount);
			}

			inactiveWhenLimited = UnityEditor.EditorGUILayout.Toggle("Inactive When Limited", inactiveWhenLimited);
		}
		
		#endif
	}
}