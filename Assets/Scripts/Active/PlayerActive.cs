using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct UnitPoint
{
    public float CurrentPoint;
    public float MaximumPoint;

    public float CurrentStock
    {
        get
        {
            return CurrentPoint;
        }
        set
        {
            if (value > MaximumPoint)
            {
                value = MaximumPoint;
            }
            else if (value < 0)
            {
                value = 0;
            }
            CurrentPoint = value;
        }
    }

    public float MaximumStock
    {
        get
        {
            return MaximumPoint;
        }
        set
        {
            CurrentPoint = MaximumPoint = value;
        }
    }
}

public class PlayerActive : MonoBehaviour
{
    public bool IsAlive;
    public bool IsGuard;
    

    public UnitState State;
    public float MoveSpeed;

    public float[] CooldownSkill;
    public UnitPoint HealthPoint;
    public UnitPoint MagicPoint;
    public UnitPoint StaminaPoint;
    public float AtkSpeed;

    public float[] CastTime { get; set; }

    private Animator playerAnim;
    private AudioSource playerAudio;
    private AudioSource attackAudio;
    private AudioSource skill_1Audio;
    private Vector2 directPos;
    private float attackTime;

    private void Player_Attack()
    {
        if (attackTime == 0 && State == UnitState.Idle)
        {
            State = UnitState.Attack;
            playerAnim.SetTrigger("Attacking");
            attackAudio.Play();
            attackTime = AtkSpeed;
        }
    }

    private void Player_Movement(Vector2 moving)
    {
        moving.Normalize();
        playerAnim.SetFloat("AxisX", directPos.x);
        playerAnim.SetFloat("AxisY", directPos.y);
        if (moving.x != 0 || moving.y != 0)
        {
            directPos = moving;
            var xAndy = Mathf.Sqrt(Mathf.Pow(moving.x, 2) +
                                   Mathf.Pow(moving.y, 2));
            var pos_x = moving.x * MoveSpeed * Time.fixedDeltaTime / xAndy;
            var pos_y = moving.y * MoveSpeed * Time.fixedDeltaTime / xAndy;
            var pos_z = transform.position.z;
            transform.Translate(pos_x, pos_y, pos_z, Space.Self);
            playerAnim.SetBool("IsMoving", true);
            if (!playerAudio.isPlaying)
            {
                playerAudio.Play();
            }
            State = UnitState.Move;
        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
            playerAudio.Stop();
            State = UnitState.Idle;
        }
    }
    private void Player_Death()
    {
        if (HealthPoint.CurrentPoint <= 0)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            IsAlive = false;
            HealthPoint.CurrentPoint = 0;
            Player_Movement(Vector2.zero);
            State = UnitState.Dead;
            playerAnim.SetTrigger("Falling");
        }
    }

    private IEnumerator Player_Attack(SkillSet skill, Action action = null)
    {
        if (CastTime[(int)skill - 1] == 0 && State == UnitState.Idle)
        {
            State = UnitState.Cast;
            playerAnim.SetTrigger(skill.ToString());
            CastTime[(int)skill - 1] = CooldownSkill[(int)skill - 1];
            switch (skill)
            {
                case SkillSet.SplashSwing:
                    skill_1Audio.Play();
                    StaminaPoint.CurrentPoint -= 20;
                    break;
                case SkillSet.DemonShell:
                    MagicPoint.CurrentPoint -= 50;
                    break;
            }
            yield return new WaitForSeconds(1f);
            action?.Invoke();
        }
    }


    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        attackAudio = transform.Find("Knight").GetComponent<AudioSource>();
        skill_1Audio = transform.Find("Abilities")
                        .Find("SplashSwing")
                        .GetComponent<AudioSource>();
        CastTime = new float[] { 0f, 0f, 0f };
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            var moveaway = Vector2.zero;
            moveaway.x = Input.GetAxis("Horizontal");
            moveaway.y = Input.GetAxis("Vertical");
            Player_Movement(moveaway);
            var gm = GameManager.Instance;
            if (Input.GetButtonDown("Jump"))
            {
                Player_Attack();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (StaminaPoint.CurrentPoint >= 20)
                {
                    StartCoroutine(Player_Attack(SkillSet.SplashSwing));
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (MagicPoint.CurrentPoint >= 50)
                {
                    StartCoroutine(Player_Attack(SkillSet.DemonShell, () => {
                        var shell = Instantiate(gm.Origin_Shell, transform);
                        Destroy(shell, 10f);
                    }));
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (HealthPoint.CurrentPoint < HealthPoint.MaximumPoint && CastTime[2] == 0)
                {
                    var effect = Instantiate(gm.Origin_CastLight, transform);
                    Destroy(effect, 1f);

                    HealthPoint.CurrentStock += 100;
                    DamageActive.PopupDamage(gm.Origin_Damage,
                                             transform.position, 100,
                                             DamageState.AllyHeal);
                    if (HealthPoint.CurrentPoint > HealthPoint.MaximumPoint)
                    {
                        HealthPoint.CurrentPoint = HealthPoint.MaximumPoint;
                    }
                    CastTime[2] = CooldownSkill[2];
                }
            }

            Player_Death();
        }

        for (int i = 0; i < CastTime.Length; i++)
        {
            if (CastTime[i] > 0f)
            {
                CastTime[i] -= Time.fixedDeltaTime;
            }

            if (CastTime[i] < 0f)
            {
                CastTime[i] = 0f;
                State = UnitState.Idle;
            }
        }

        if (attackTime > 0f)
        {
            attackTime -= Time.fixedDeltaTime;
        }

        if (attackTime < 0f)
        {
            attackTime = 0f;
            State = UnitState.Idle;
        }

        IsGuard = transform.Find("ShellEffect(Clone)");

    }
}

