public interface IStateMachine
{
    void InitData();
    void Enter();
    void Execute();
    void Exit();
}
