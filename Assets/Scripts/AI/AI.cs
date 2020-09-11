using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent aiAgent;

    [SerializeField]
    private Transform[] finishLinePos;

    // Start is called before the first frame update
    void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //the AI will move to finishline position.
        aiAgent.SetDestination(finishLinePos[LevelGenerator.randPos].transform.position);
    }
}
