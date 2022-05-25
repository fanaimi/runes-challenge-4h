using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge6
{
    [CreateAssetMenu(fileName = "Chest Config", menuName = "Configs/Chest", order = 2)]
    public class ChestConfig : ScriptableObject
    {
        public string m_name;

        public List<string> m_weapons = new List<string> { "dap", "ngao", "plong", "krabong" };
        public List<int> m_pecents = new List<int> { 30, 20, 25, 25 };
    }

} // namespace