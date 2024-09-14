using System;
using UnityEngine.InputSystem;  
using UnityEngine;

namespace Hands.Scripts
{
	public class NewBehaviourScript : MonoBehaviour
	{
		[SerializeField] private Animator handAnimator;
		[SerializeField] private InputActionReference triggerActionRef;
		[SerializeField] private InputActionReference gripActionRef;

		private static  int TriggerAnimation = Animator.StringToHash("Trigger");
		private static  int GripAnimation = Animator.StringToHash("Grip");


		private void Update(){
			float triggerValue = triggerActionRef.action.ReadValue<float>();
			handAnimator.SetFloat(TriggerAnimation, triggerValue);

			float gripValue = gripActionRef.action.ReadValue<float>();
			handAnimator.SetFloat(GripAnimation, gripValue);
		}

	}
}
