using System.Collections;
using System.Collections.Generic;
using InHwan.Board;
using UnityEngine;
using InHwan.Scriptable;

namespace InHwan.Board
{
    public class CellBehaviour : MonoBehaviour
    {
        Cell m_Cell;
        SpriteRenderer m_SpriteRenderer;
        [SerializeField] CellConfig m_CellConfig;

        // Start is called before the first frame update
        void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();

            UpdateView(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetCell(Cell cell)
        {
            m_Cell = cell;
        }

        /// <summary>
        /// 참조하고 있는 Cell의 정보를 반영하여 Cell GameObject에 반영한다
        /// ex) Cell 종류에 따른 Sprite 종류 업데이트
        /// 생성자 또는 플레이도중에 Cell Type이 변경될 때 호출된다.
        /// </summary>
        /// <param name="bValueChanged">플레이 도중에 Type이 변경되는 경우 true, 그렇지 않은 경우 false</param>
        public void UpdateView(bool bValueChanged)
        {
            if (m_Cell.type == CellType.EMPTY)
            {
                m_SpriteRenderer.sprite = null;
            }
            if (m_Cell.type == CellType.HOLE)
            {
                m_SpriteRenderer.sprite = m_CellConfig.HoleCellSprite;
            }
        }

    }
}