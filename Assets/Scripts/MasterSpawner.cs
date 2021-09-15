using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MasterSpawner : MonoBehaviour
{
    public GameObject RegularGround = null;
    public GameObject SpikesGround = null;
    
    private GroundMover mover;
    private bool aTrigger;
    private GameObject currentGround;
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
        
        aTrigger = true;
        SpawnMoreGround("First");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool trigger = check.tickTrigger;
        
        if (trigger)
        {
          SpawnMoreGround("Additional");
          trigger = false;
        }

    }

    void SpawnMoreGround(string addType)
    { 
        if (index > 1)
        {
            index = 0;
        }
        
        if (groundDict.ContainsKey(index))
        {
            Destroy(groundDict[index]);
            groundDict.Remove(index);
        }
        
        if (addType == "Additional")
        {
            Transform[] trans = currentGround.GetComponentsInChildren<Transform>();
            Transform tran = trans[2];
            InstanceGround(tran.position, "Random");
            BoxCollider[] movers = currentGround.GetComponentsInChildren<BoxCollider>();
            check = movers[1].GetComponent<TriggerCheck>();
            mover = currentGround.GetComponent<GroundMover>();
            aTrigger = false;
            mover.move = true;
            mover.moveSpeed = 2;
        }
        else if (addType == "First")
        {
            InstanceGround(new Vector3(-10,0,0), "First");
            
            mover = currentGround.GetComponent<GroundMover>();
            BoxCollider[] movers = currentGround.GetComponentsInChildren<BoxCollider>();
            check = movers[1].GetComponent<TriggerCheck>();
            aTrigger = false;
            mover.move = true;
            mover.moveSpeed = 2;
        }
        
        groundDict.Add(index, currentGround);
        index++;
    }
    
    
    void InstanceGround(Vector3 pos, string spawnType)
    {
        GameObject spawnObject = RegularGround;
        
        if (spawnType == "First")
        {
            spawnObject = RegularGround;
        }
        
        else if (spawnType == "Random")
        {
            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                spawnObject = SpikesGround;
            }
            else if (rand == 1)
            {
                spawnObject = RegularGround;
            }
            else if (rand == 2)
            {
                spawnObject = RegularGround;
            }
        }
        else
        {
            spawnObject = RegularGround;
        }
        
        currentGround = Instantiate(spawnObject, pos, Quaternion.identity);
    }
    
    void ClearGround()
    {
        
    }
    
    void AdjustDictionary()
    {
        
    }
}
