using UnityEngine;
using UnityEngine.AI;

public class CharacterMouseClickMovement : CharacterMovement
{
    [Header("Mouse")]
    [SerializeField] private ParticleSystem _mouseClickEffect;

    public override float CurrentSpeed => _agent.velocity.magnitude;

    public override void Stop()
    {
        _agent.ResetPath();
    }

    public override void Wrap(Vector3 position, Quaternion rotation)
    {
        Agent.Warp(position);
        Character.transform.rotation = rotation;
    }

    protected override void AfterGameLoaded()
    {
        FollowOtherCharacter();
    }

    protected override void HandleInput()
    {
        if (Character.Input.Clicked)
        {
            var hit = Character.Input.Hit;
            Tasks.Clear();
            _agent.SetDestination(hit.point);
            _mouseClickEffect.transform.position = hit.point;
            _mouseClickEffect.Play();
        }
    }

    private void FollowOtherCharacter()
    {
        // todo separate to other class
        Character.Input.MouseInteraction.Add(new MovementMouseListener<Character>((other) =>
        {
            Tasks.Add(new MovementTask
            {
                Condition = () => Vector3.Distance(Character.Position, other.Position) < 4f,
                Do = () => Stop(),
                Otherwise = () => _agent.SetDestination(other.Position),
                DisableAutoDelete = true
            });
        }));
    }

    private void UpdateAgent()
    {
        _agent.speed = Speed;
    }

    protected void Reset()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected override void OnSpeedChange()
    {
        // todo very awful method
        _agent.speed = Speed;
    }
}
