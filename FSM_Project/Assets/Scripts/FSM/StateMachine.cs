using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState m_CurrentState;
    private Dictionary<Type, List<Transition>> m_Transitions;
    private List<Transition> m_CurrentTransitions;
    private List<Transition> m_AnyTransitions;
    private static List<Transition> EmptyTransitions;

    public StateMachine()
    {
        m_Transitions = new Dictionary<Type, List<Transition>>();
        m_CurrentTransitions = new List<Transition>();
        m_AnyTransitions = new List<Transition>();
        EmptyTransitions = new List<Transition>();
    }

    public void Update()
    {
        Transition transition = GetTransition();
        if(transition != null)
        {
            SetState(transition.To);
        }

        if(m_CurrentState != null)
        {
            m_CurrentState.Update();
        }
    }

    public void SetState(IState state)
    {
        if(state == m_CurrentState)
        {
            return;
        }

        if(m_CurrentState != null)
        {
            m_CurrentState.OnExit();
        }

        m_CurrentState = state;

        m_Transitions.TryGetValue(m_CurrentState.GetType(), out m_CurrentTransitions);

        if(m_CurrentTransitions == null)
        {
            m_CurrentTransitions = EmptyTransitions;
        }

        m_CurrentState.OnEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        if(m_Transitions.TryGetValue(from.GetType(), out var transitions) == false)
        {
            transitions = new List<Transition>();
            m_Transitions[from.GetType()] = transitions;
        }

        transitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        m_AnyTransitions.Add(new Transition(state, predicate));
    }

    private Transition GetTransition()
    {
        foreach(Transition trans in m_AnyTransitions)
        {
            if(trans.Condition())
            {
                return trans;
            }
        }

        foreach(Transition trans in m_CurrentTransitions)
        {
            if(trans.Condition())
            {
                return trans;
            }
        }

        return null;
    }
}
