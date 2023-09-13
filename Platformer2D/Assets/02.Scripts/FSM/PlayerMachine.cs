using UnityEngine;

public class PlayerMachine : CharacterMachine
{

    public override float horizontal 
    {
        get => Input.GetAxisRaw("Horizontal");
        
        set => base.horizontal = value; 
    }
    private void Start()
    {
        Initialize(CharacterStateWorkflowsDataSheet.GetWorkflowsForPlayer(this));
    }

    public override float vertical
    { 
        get => Input.GetAxisRaw("Vertical"); 
        set => base.vertical = value; 
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if (ChangeState(State.JumpDown) == false) 
           if (ChangeState(State.Jump) == false)
                ChangeState(State.SecondJump);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            ChangeState(State.LedgeClimb);
        }
        if (Input.GetKey(KeyCode.UpArrow) )
        {
            if (canLadderUp)
                ChangeState(State.LadderClimbing, new object[] { upLadder, DiRECTION_UP });
            ChangeState(State.Ledge);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (canLadderDown)
                ChangeState(State.LadderClimbing, new object[] { downLadder, DiRECTION_DOWN });
            else
               ChangeState(State.Crouch);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (current == State.Crouch)
            ChangeState(State.Idle);
        }
    }
}