﻿using UnityEngine;

namespace Assets.Scripts.Game.brnn3d
{
    public class StateUI : MonoBehaviour
    {
        public static StateUI Instance;
        public Transform[] StateTfs = new Transform[5];

        protected void Awake()
        {
            Instance = this;

        }

        public void SetStateUI(int stateId)
        {
            foreach (var tf in StateTfs)
            {
                if (tf.gameObject.activeSelf)
                    tf.gameObject.SetActive(false);
            }
            StateTfs[stateId].gameObject.SetActive(true);
        }

    }
}

