using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG {
    public class WashHandsScript : MonoBehaviour
    {
        public ScrubStepDetector scrubStepDetectorScript;
        public GameObject handRBubblesUI;
        public GameObject handLBubblesUI;
        public bool playerCurrentlyWashingHands;
        public bool playerCurretnlySoapyHands;

        void Start(){
            playerCurrentlyWashingHands = false;
            playerCurretnlySoapyHands = false;
        }


        //Step 4: Checks if player collides with water
        public void OnTriggerEnter(Collider other){
            if (other.gameObject.tag == "Player" && scrubStepDetectorScript.currentStep == 4){
                scrubStepDetectorScript.playerWashedHands = true;
                playerCurrentlyWashingHands = true;
            }
            else if (other.gameObject.tag == "Player" && scrubStepDetectorScript.currentStep == 21)
            {
                scrubStepDetectorScript.playerRinseHands = true;
            }
            else if (other.gameObject.tag == "Player"){
                playerCurrentlyWashingHands = true;
            }
        }
        public void OnTriggerExit(Collider other){
            if (other.gameObject.tag == "Player"){
                playerCurrentlyWashingHands = false;
            }
        }


        //Run when player presses button on soap dispenser and makes hands soapy
        public void SoapyHands(){
            scrubStepDetectorScript.playerSoapHands = true;
            playerCurretnlySoapyHands = true;
            handRBubblesUI.SetActive(true);
            handLBubblesUI.SetActive(true);
            StartCoroutine(TurnOffSoapyHands());
            if (scrubStepDetectorScript.currentStep == 12){
                scrubStepDetectorScript.playerRESoapHands = true;
            }
        }

        //Turns off soap bubble UI at hands when player contacts water stream or just after 15 seconds
        IEnumerator TurnOffSoapyHands()
        {
            if (playerCurrentlyWashingHands == true)
            {
                yield return new WaitForSeconds(2.5f);
                handRBubblesUI.SetActive(false);
                handLBubblesUI.SetActive(false);
                playerCurretnlySoapyHands = false;
                Debug.Log("player touched water. bubbles byebye");
            }
            else
            {
                yield return new WaitForSeconds(10f);
                handRBubblesUI.SetActive(false);
                handLBubblesUI.SetActive(false);
                playerCurretnlySoapyHands = false;
            }
        }


    }
}
