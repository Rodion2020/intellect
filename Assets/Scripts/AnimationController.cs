using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float RunVelocity = 0.1f;
    public string AnimationRunParamName = "Run";

    private NavMeshAgent ThisNavMeshAgent = null;
    private Animator ThisAnimator = null;

    public string AnimationSpeedParamName = "Speed";
    private float MaxSpeed;

    void Awake()
    {
        ThisNavMeshAgent = GetComponent<NavMeshAgent>();
        ThisAnimator = GetComponent<Animator>();
        MaxSpeed = ThisNavMeshAgent.speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisAnimator.SetBool(AnimationRunParamName, ThisNavMeshAgent.velocity.magnitude > RunVelocity);
        ThisAnimator.SetFloat(AnimationSpeedParamName, ThisNavMeshAgent.velocity.magnitude / MaxSpeed);
    }
}
