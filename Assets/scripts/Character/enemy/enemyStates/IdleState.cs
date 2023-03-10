using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{

    private enemy parent;
    // Start is called before the first frame update
    public void Enter(enemy parent)
    {
        this.parent = parent;
        this.parent.animator.SetFloat("Speed", 0);

    }

    
    // Update is called once per frame
    public void Update()
    {
        // Debug.Log("IDLE");
          if (parent.Target != null)
        {
            parent.ChangeState(new FollowState());

            
        }
    }

    public void Exit()
    {

    }
}
