using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    //prepare the states
    void Enter(enemy parent);

    void Update();

    void Exit();
}
