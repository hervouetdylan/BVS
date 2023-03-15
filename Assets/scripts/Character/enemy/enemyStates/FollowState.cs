using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


class FollowState : IState
{
    private enemy parent;
    // Start is called before the first frame update
    public void Enter(enemy parent)
    {
        this.parent = parent;
    }

    
    // Update is called once per frame
    public void Update()
    {
        // Debug.Log("FOLLOWING");
        if (parent.Target != null)
        {
            parent.Direction = (parent.Target.transform.position - parent.transform.position).normalized;
            parent.transform.position = Vector2.MoveTowards(parent.transform.position, parent.Target.position, parent.Speed*Time.deltaTime);

            // float distance = Vector2.Distance (parent.transform.position, parent.Target.transform.position);
            if (parent.RangeAttack)
            {
                parent.ChangeState(new AttackState());
            }

            parent.animator.SetFloat("Horizontal",parent.Direction.x);
            parent.animator.SetFloat("Vertical",parent.Direction.y);
            parent.animator.SetFloat("Speed",parent.Direction.sqrMagnitude);
        }else{
            parent.ChangeState(new IdleState());
        }
        
    }

    public void Exit()
    {

    }

}