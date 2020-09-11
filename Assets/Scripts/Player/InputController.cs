using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool nextLevel;
    public bool move;

    private void Update()
    {
        nextLevel = Input.GetKey(KeyCode.Space);
        move = Input.GetMouseButton(0);
    }
}
