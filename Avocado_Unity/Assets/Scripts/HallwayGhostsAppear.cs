using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class HallwayGhostsAppear : MonoBehaviour
    {
        public GameObject hallwayGhost;
        public GameObject myInstancedHallwayGhost1;
        public GameObject myInstancedHallwayGhost2;
        public GameObject myInstancedHallwayGhost3;

        public Transform spawnPoint1;
        public Transform spawnPoint2;
        public Transform spawnPoint3;

        // Start is called before the first frame update
        void Start()
        {
            myInstancedHallwayGhost1 = Instantiate(hallwayGhost, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            myInstancedHallwayGhost2 = Instantiate(hallwayGhost, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            myInstancedHallwayGhost3 = Instantiate(hallwayGhost, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
