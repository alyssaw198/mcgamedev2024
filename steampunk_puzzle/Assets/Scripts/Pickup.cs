    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Backpack", menuName = "Backpack")]
    public class Backpack : ScriptableObject
    {
        [SerializeField] int keys = 0;

        public int GetKeys { get => keys; }
        public void UpdateKeys(int numberOfKeys) { keys += numberOfKeys; }
    }

