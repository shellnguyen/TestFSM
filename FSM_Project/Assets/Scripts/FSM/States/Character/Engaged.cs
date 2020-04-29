using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engaged : IState
{
    private EnemyController m_Enemy;

    public Engaged(EnemyController enemy)
    {
        m_Enemy = enemy;
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void Update()
    {
        m_Enemy.Explode();
    }
}
