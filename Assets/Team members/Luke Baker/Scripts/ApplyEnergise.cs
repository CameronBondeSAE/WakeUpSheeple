using AlexM;
using DG.Tweening;
using UnityEngine;

namespace LukeBaker
{
    public class ApplyEnergise : MonoBehaviour
    {
        //This script needs work, figure out what energise does and it would make it easier.
        //variables
        public TriggerMarshaller energiserTrigger;

        //Tweening or animation variables
        [Tooltip("The duration of the energise movement")]
        public float energiseDuration;

        [Tooltip("The time waiting for the object that is energised to move")]
        public float waitForEnergise;

        [Tooltip("The animation type for the movement of the energised object")]
        public Ease ease;

        [Tooltip("When the energiser is triggered by an object, the object will moves toward the energiseEndPosition"),
         Header("Required")]
        public Transform energiseEndPosition;

        //Event Subscription
        private void OnEnable()
        {
            energiserTrigger.onTriggerEnterEvent += EnergiseObject;
        }

        private void OnDisable()
        {
            energiserTrigger.onTriggerExitEvent -= EnergiseObject;
        }

        ///Function for the inner collider of the 5G tower leads the object into a death or damage trap
        void EnergiseObject(Collider trigger)
        {
            Sheep findSheep = trigger.GetComponent<Sheep>();

            if (findSheep != null)
            {
                //this will lead black sheep into death traps but I want it smoother than a current DoTween
                if (findSheep.IsBlack)
                {
                    var sequence = DOTween.Sequence();
                    sequence.Append(trigger.gameObject.transform.DOMove(energiseEndPosition.position,
                        energiseDuration * Time.deltaTime, true)).SetDelay(waitForEnergise).SetEase(ease);
                }

                //This will make the white sheep follow the black sheep
                else if (findSheep.IsBlack == false)
                {
                    Debug.Log("is white sheep");
                }
            }
        }
    }
}