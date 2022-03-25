using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum EnemySet
    {
        Default, Damaged, Native, Warrior, Witch, Skeleton,
    }

    public enum UnitState
    {
        Idle, Move, Attack, Cast, Dead,
    }
}
