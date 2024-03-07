using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    readonly int idle = Animator.StringToHash("Player_Idle");
    readonly int jump = Animator.StringToHash("Player_Jump");
    readonly int fall = Animator.StringToHash("Player_Fall");
    readonly int crouch = Animator.StringToHash("Player_Crouch");   
    readonly int attack = Animator.StringToHash("Player_Attack");

    public enum PlayerAnimations { Idle, Jump, Fall, Crouch, Attack }
    Dictionary<PlayerAnimations, int> NameToAnimation;

    void Start()
    {
        NameToAnimation = new Dictionary<PlayerAnimations, int>()
        {
            { PlayerAnimations.Idle,    idle    },
            { PlayerAnimations.Attack,  attack  },
            { PlayerAnimations.Crouch,  crouch  },
            { PlayerAnimations.Fall,    fall    },
            { PlayerAnimations.Jump,    jump    },
        };
    }

    public void PlayAnimation(PlayerAnimations animation, float animationCrossfade = 0)
    {
        if (NameToAnimation.TryGetValue(animation, out var hash))
            animator.CrossFade(hash, animationCrossfade);
        else
            Debug.LogWarning("Animation not found");
    }
}
