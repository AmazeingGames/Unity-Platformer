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
    readonly int crouchIdle = Animator.StringToHash("Player_CrouchIdle");
    readonly int stand = Animator.StringToHash("Player_Stand");
    readonly int attack = Animator.StringToHash("Player_Attack");

    public enum PlayerAnimations { Idle, Jump, Fall, Crouch, Attack, Stand, CrouchIdle }
    Dictionary<PlayerAnimations, int> NameToAnimation;

    void Start()
    {
        NameToAnimation = new Dictionary<PlayerAnimations, int>()
        {
            { PlayerAnimations.Idle,        idle        },
            { PlayerAnimations.Attack,      attack      },
            { PlayerAnimations.Crouch,      crouch      },
            { PlayerAnimations.CrouchIdle,  crouchIdle  },
            { PlayerAnimations.Stand,       stand       },
            { PlayerAnimations.Fall,        fall        },
            { PlayerAnimations.Jump,        jump        },
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayAnimation(PlayerAnimations.Idle);

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayAnimation(PlayerAnimations.Attack);

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            PlayAnimation(PlayerAnimations.Crouch);

        else if (Input.GetKeyDown(KeyCode.Alpha4))
            PlayAnimation(PlayerAnimations.CrouchIdle);

        else if (Input.GetKeyDown(KeyCode.Alpha5))
            PlayAnimation(PlayerAnimations.Stand);

        else if (Input.GetKeyDown(KeyCode.Alpha6))
            PlayAnimation(PlayerAnimations.Fall);

        else if (Input.GetKeyDown(KeyCode.Alpha7))
            PlayAnimation(PlayerAnimations.Jump);
    }

    public void PlayAnimation(PlayerAnimations animation, float animationCrossfade = 0)
    {
        if (NameToAnimation.TryGetValue(animation, out var hash))
        {
            Debug.Log($"Played animation : {animation}");
            animator.CrossFade(hash, animationCrossfade);
        }
        else
            Debug.LogWarning("Animation not found");
    }
}
