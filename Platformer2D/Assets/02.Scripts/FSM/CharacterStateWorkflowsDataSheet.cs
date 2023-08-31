using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Rendering;
using UnityEngine;

public static class CharacterStateWorkflowsDataSheet
{
    public abstract class WorkflowBase : IWorkflow<State>
    {
        public abstract State ID { get; }

        public int Current => current;
        protected int current;

        protected CharacterMachine machine;
        protected Transform transform;
        protected Rigidbody2D rigidbody;
        protected CapsuleCollider2D collider;
        protected Animator animator;
        
        public WorkflowBase(CharacterMachine machine)
        {
            this.animator = machine.animator;
            this.machine = machine;
            this.transform = machine.transform;
            this.rigidbody = machine.GetComponent<Rigidbody2D>();
            this.collider = machine.GetComponent<CapsuleCollider2D>();
        }

        public abstract State MoveNext();


        public void Reset()
        {
            current = 0;
        }
    }
    public class Idle : WorkflowBase
    {
        public override State ID => State.Idle;
        public Idle(CharacterMachine machine) : base(machine)
        {
        }
        public override State MoveNext()
        
         
        {
            State next = ID;

            switch (current)
            {
                case 0:
                    {
                        machine.isDirectionChangeable = true;
                        machine.isMovable = true;
                        animator.Play("Idle");
                        current++;
                    }
                    break;
                default:
                    {
                        if (Mathf.Abs(machine.horizontal) > 0)
                            next = State.Move;
                        // todo -> X 축 입력 절댓값이 0보다 크면 next = State.Move


                        // todo -> Ground 가 감지되지 않으면 next = State.Fall
                    }
                    break;
            }

            return next;
        }
    }


    public class Move : WorkflowBase
    {


        public override State ID => State.Move;
        public Move(CharacterMachine machine) : base(machine)
        {
        }
        public override State MoveNext()
        {
            State next = ID;

            switch (current)
            {
                case 0:
                    {
                        machine.isDirectionChangeable = true;
                        machine.isMovable = true;
                        animator.Play("Move");
                        current++;
                    }
                    break;
                default:
                    {
                        if ((machine.horizontal) == 0.0f)
                           
                            next = State.Idle;
                           
                        // todo -> X 축 입력 절댓값이 0보다 크면 next = State.Move


                        // todo -> Ground 가 감지되지 않으면 next = State.Fall
                    }
                    break;
            }

            return next;
        }
    }


    public static IEnumerable<KeyValuePair<State, IWorkflow<State>>> GetWorkflowsForPlayer(CharacterMachine machine)
    {
        return new Dictionary<State, IWorkflow<State>>()
        {
          { State.Idle, new Idle(machine) },
          { State.Move, new Move(machine) },
        };
    }
}