using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private enemy parent;

    public void Enter(enemy parent)
    {
        this.parent = parent;
    }

    
    // Update is called once per frame
    public void Update()
    {
        // Debug.Log("ATTACK");
       if (parent.Target != null)
       {
            parent.Direction = (parent.Target.transform.position - parent.transform.position).normalized;

            // float distance = Vector2.Distance (parent.transform.position, parent.Target.transform.position);

            parent.animator.SetFloat("Horizontal",parent.Direction.x);
            parent.animator.SetFloat("Vertical",parent.Direction.y);
            parent.animator.SetFloat("Speed", 0);


            if (!parent.RangeAttack)
            {
                parent.ChangeState(new FollowState());
            }
       }else
       {
        parent.ChangeState(new IdleState());
       }
    }

    public void Exit()
    {

    }
}
