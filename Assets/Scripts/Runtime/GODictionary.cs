using System.Collections.Generic;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime
{
    public static class GODictionary
    {
        public static Dictionary<GameObject, IVulnerable> VulnerableGOs { get; private set; } =
            new Dictionary<GameObject, IVulnerable>();

        public static void AddVulnerableGO(GameObject key, IVulnerable vulnerable)
        {
            VulnerableGOs.Add(key, vulnerable);
        }

        public static void RemoveVulnerableGO(GameObject key)
        {
            VulnerableGOs.Remove(key);
        }
    }
}