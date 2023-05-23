using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InstantStateChangerList : StateChanger
    {
        [SerializeField] List<StateChanger> interactors;

        public override State State
        {
            get { return state; }
            set
            {
                state = value;
                foreach (StateChanger stateChanger in interactors)
                {
                    stateChanger.State = value;
                }
            }
        }
    }
}
