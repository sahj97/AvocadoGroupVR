using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class GhostCounter : MonoBehaviour
    {
        [Header ("GameObjects")]
        public GameObject startRoomDoorR;
        public GameObject startRoomDoorL;
        public GameObject doorBlocker1;
        public GameObject doorBlocker2;
        public GameObject scrubRoomDoorR;
        public GameObject scrubRoomDoorL;

        [Header ("Animations")]
        public Animator ghostBossAnim;
        public Animator doorOR;
        public Animator avoHelper;

        [Header ("Tracking")]
        public int numberGhostsKilled = 0;
        public int numberGoosCleaned = 0;
        public bool scrubRoomUnlocked = false;
        public bool ghostBossKilled = false;
        public bool allGooGones = false;


        // Start is called before the first frame update
        void Start()
        {
            numberGhostsKilled = 0;
            numberGoosCleaned = 0;
            ghostBossKilled = false;
            allGooGones = false;
            scrubRoomUnlocked = false;
        }

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(UnlockStartDoors());
            StartCoroutine(UnlockScrubRoomDoors());
        }

        public void GhostiesKilled()        //this is run on the destroy event of the damagale script on ghosts
        {
            numberGhostsKilled++;
            Debug.Log(numberGhostsKilled + "ghost killed (ghost kill script)");

            if (numberGhostsKilled == 5)
            {
                ghostBossKilled = true;
            }
        }    

        //Checks if you have killed the first starting ghost to unlock the first set of doors
        public IEnumerator UnlockStartDoors(){
            Debug.Log("Check if start door unlocked");
            yield return new WaitUntil(OneGhostDown);
            startRoomDoorR.GetComponent<DoorHelper>().DoorIsLocked = false;
            startRoomDoorR.GetComponent<DoorHelper>().handleLocked = false;
            startRoomDoorL.GetComponent<DoorHelper>().DoorIsLocked = false;
            startRoomDoorL.GetComponent<DoorHelper>().handleLocked = false;
            scrubRoomUnlocked = true;
            Destroy(doorBlocker1);
            ghostBossAnim.Play("GhostBOSS");

            Debug.Log("Start door is unlocked");
        }
        bool OneGhostDown()
        {
            if (numberGhostsKilled >= 1 && numberGoosCleaned >=5){
                //Debug.Log("testing testing");
                return true;
            }
            else{
                return false;
            }
        }
     

        //Checks if you have killed all ghosts to unlock the scrub room doors
        public IEnumerator UnlockScrubRoomDoors()
        {
            Debug.Log("Check if scrub room unlocked");
            yield return new WaitUntil(AllClear);
            scrubRoomDoorR.GetComponent<DoorHelper>().DoorIsLocked = false;
            scrubRoomDoorR.GetComponent<DoorHelper>().handleLocked = false;
            scrubRoomDoorL.GetComponent<DoorHelper>().DoorIsLocked = false;
            scrubRoomDoorL.GetComponent<DoorHelper>().handleLocked = false;
            Destroy(doorBlocker2);

            Debug.Log("Scrub room unlocked");
        }
        bool AllClear()
        {
            if (numberGhostsKilled >= 4 && numberGoosCleaned >=20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void BringInTheAvo()
        {
            doorOR.Play("ScrubDoorOpen");
            avoHelper.Play("AvoWalkInRoom");
        }



    }
}
