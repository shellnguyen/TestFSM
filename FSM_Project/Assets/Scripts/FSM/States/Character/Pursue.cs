using UnityEngine.AI;

public class Pursue : CharacterState
{
    public Pursue(CharacterController controller) : base(controller)
    {
    }

    public override void OnEnter()
    {
        m_Controller.Animator.SetFloat("Speed", 1.0f);
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
        m_Controller.Pursue();
    }
}
