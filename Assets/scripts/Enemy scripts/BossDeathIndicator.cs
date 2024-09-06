using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathIndicator : MonoBehaviour
{

    // Update is called once per frame
    void OnDestroy()
    {
        GameObject stateMachine = GameObject.FindGameObjectWithTag("StateMachine"); // Use tag StateMachine on this GameObject
        stateMachine.GetComponent<spawnenemy>().ChangeState(levelState.showCards, false); // StateMachine is the name of this component
    }
}
