namespace JHFBehaviorTree
{
    public class Inverter : Decorator
    {
        public Inverter(Node child) : base(child) { }

        public override NodeStatus OnUpdate()
        {
            NodeStatus state = _child.Evaluate();
            if (state == NodeStatus.Running)
            {
                _state = state;
                return _state;
            }

            _state = (state == NodeStatus.Failure) ? NodeStatus.Success : NodeStatus.Failure;
            return _state;
        }
    }
}
