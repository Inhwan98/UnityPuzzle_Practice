using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InHwan.Scriptable
{
    [CreateAssetMenu(menuName = "InHwanPuzzle/Cell Config", fileName = "CellConfig.asset")]
    public class CellConfig :ScriptableObject
    {
        public Sprite HoleCellSprite;
    }
}
