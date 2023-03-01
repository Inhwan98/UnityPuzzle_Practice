using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InHwan.Board;

namespace InHwan.Scriptable
{
    [CreateAssetMenu(menuName = "InHwanPuzzle/UIConfig", fileName = "UIConfig.asset")]
    public class UIConfig : ScriptableObject
    {
        public BlockBreed TargetBlock;
        public int CntStage;
        public int CntMove;
        public int CntTarget;

        public int EndCntTarget;
    }
}
