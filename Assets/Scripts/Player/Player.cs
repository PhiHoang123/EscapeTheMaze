using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Player : MonoBehaviour
{
    //check which obj player can be clicked on.
    public LayerMask whatCanBeClickedOn;

    //Navmesh
    public NavMeshAgent myAgent;

    //Input controller
    private InputController _inputController;

    //to next level events
    public static Action toNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        _inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ToNextLevel();
    }

    //player movement
    void Move()
    {
        if (_inputController.move)
        {
            //Draw a line from camera to the mouse position.
            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Contains all informations about what the ray hit  
            RaycastHit hitInfo;

            if (Physics.Raycast(myray, out hitInfo, 100, whatCanBeClickedOn))
            {
                //move player to the position of the point player clicked
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }

    //when player reach the finish line, press space to next level
    void ToNextLevel()
    {
        if(FinishLine.isFinished == true)
        {
            if (_inputController.nextLevel)
            {
                if (toNextLevel != null)
                    toNextLevel();
                FinishLine.isFinished = false;
            }
        }

    }

}
