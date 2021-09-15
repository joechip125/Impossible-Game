using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpawner : MonoBehaviour
{
    public GameObject simpleSpawn = null;
    private GroundMover mover;
    private bool aTrigger;
    private GameObject keep;
    private BoxCollider collider;
    [SerializeField] TriggerCheck check;
    private BoxCollider groundCollider;
    private List<GameObject> groundList;
    private Dictionary<int, GameObject> groundDict;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        groundDict = new Dictionary<int, GameObject>();
        groundList = new List<GameObject>();
        index = 0;
        
        keep = Instantiate(simpleSpawn, new Vector3(-10, 0, 0), Quaternion.identity);
        BoxCollider[] movers;  
        mover = keep.GetComponent<GroundMover>();
        movers = keep.GetComponentsInChildren<BoxCollider>();

        check = movers[1].GetComponent<TriggerCheck>();
        
        mover.move = true;
        mover.moveSpeed = 2;
        aTrigger = true;
        //    Random.Range(0, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool trigger = check.tickTrigger;
        
        if (trigger && aTrigger)
        {
          SpawnMoreGround("Additional");
          trigger = false;
        }

    }

    void SpawnMoreGround(string addType)
    {
        
        if (addType == "Additional")
        {
            Transform[] trans = keep.GetComponentsInChildren<Transform>();
            Transform tran = trans[2];
            keep = Instantiate(simpleSpawn, tran.position, Quaternion.identity);
            mover = keep.GetComponent<GroundMover>();
            aTrigger = false;
        }
        else if (addType == "First")
        {
            index = 0;
            Transform[] trans = keep.GetComponentsInChildren<Transform>();
            Transform tran = trans[2];
            keep = Instantiate(simpleSpawn, new Vector3(-10, 0, 0), Quaternion.identity);
            mover = keep.GetComponent<GroundMover>();
            aTrigger = false;
        }
        groundDict.Add(index, keep);
    }

    void AdjustDictionary()
    {
        
    }
}
