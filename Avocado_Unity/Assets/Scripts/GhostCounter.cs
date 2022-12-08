using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG
{
    public class GhostCounter : MonoBehaviour
    {
        [Header ("Game Objects for Ghost Fighting")]
        public GameObject startRoomDoorR;
        public GameObject startRoomDoorL;
        public GameObject mainStartDoor;
        public GameObject myLockStart;
        public GameObject myUnlockStart;
        public GameObject doorBlocker1;
        public GameObject visionObscur;
        public GameObject doorBlocker2;
        public GameObject scrubRoomDoorR;
        public GameObject scrubRoomDoorL;
        public GameObject myLockScrub;
        public GameObject myUnlockScrub;
        public AudioSource unlockSound;

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
        void Start(){
            numberGhostsKilled = 0;
            numberGoosCleaned = 0;
            ghostBossKilled = false;
            allGooGones = false;
            scrubRoomUnlocked = false;
        }

        // Update is called once per frame
        void Update(){
            StartCoroutine(UnlockStartDoors());
            StartCoroutine(UnlockScrubRoomDoors());
        }

        public void GhostiesKilled() {        //this is run on the destroy event of the damagable script on ghosts, keeps track of how many ghosts killed
            numberGhostsKilled++;
            Debug.Log(numberGhostsKilled + "ghost killed (from damagable script)");
            if (numberGhostsKilled == 5){
                ghostBossKilled = true;
            }
        }    

        //Checks if you have killed the first starting ghost to unlock the first set of doors
        public IEnumerator UnlockStartDoors(){
            //Debug.Log("Check if start door unlocked");
            yield return new WaitUntil(OneGhostDown);
            startRoomDoorR.GetComponent<DoorHelper>().DoorIsLocked = false;
            startRoomDoorR.GetComponent<DoorHelper>().handleLocked = false;
            startRoomDoorL.GetComponent<DoorHelper>().DoorIsLocked = false;
            startRoomDoorL.GetComponent<DoorHelper>().handleLocked = false;
            scrubRoomUnlocked = true;
            myLockStart.SetActive(false);
            myUnlockStart.SetActive(true);
            unlockSound.Play();
            Destroy(doorBlocker1);
            Destroy(visionObscur);
            //Debug.Log("Start door is unlocked");
        }
        bool OneGhostDown(){
            if (numberGhostsKilled >= 1 && numberGoosCleaned >=4){
                //Debug.Log("testing testing");
                return true;
            }
            else{
                return false;
            }
        }
     
        //Checks if you have killed ALL ghosts to unlock the scrub room doors
        public IEnumerator UnlockScrubRoomDoors(){
            //Debug.Log("Check if scrub room unlocked");
            yield return new WaitUntil(AllClear);
            scrubRoomDoorR.GetComponent<DoorHelper>().DoorIsLocked = false;
            scrubRoomDoorR.GetComponent<DoorHelper>().handleLocked = false;
            scrubRoomDoorL.GetComponent<DoorHelper>().DoorIsLocked = false;
            scrubRoomDoorL.GetComponent<DoorHelper>().handleLocked = false;
            myLockScrub.SetActive(false);
            myUnlockScrub.SetActive(true);
            unlockSound.Play();
            Destroy(doorBlocker2);

            Debug.Log("Scrub room unlocked");
        }
        bool AllClear(){ //bool for UnlockScrubRoomDoors
            if (numberGhostsKilled >= 5 && numberGoosCleaned >=20){
                return true;
            }
            else{
                return false;
            }
        }



    }
}
