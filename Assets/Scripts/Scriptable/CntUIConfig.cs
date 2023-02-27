using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InHwan.Scriptable
{
    [CreateAssetMenu(menuName = "InHwanPuzzle/CntUIConfig", fileName = "CntUIConfig.asset")]
    public class CntUIConfig : ScriptableObject
    {
        public int CntStage;
        public int CntMove;
        public int CntTarget;
    }
}
