using UnityEngine;

namespace Task2
{
    public abstract class State : MonoBehaviour
    {
        public virtual void Enter()
        {
        }
        public virtual void Exit()
        {
        }
    }
}