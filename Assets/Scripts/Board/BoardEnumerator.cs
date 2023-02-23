using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InHwan.Board;

namespace InHwan.Board
{
    public class BoardEnumerator
    {
        InHwan.Board.Board m_Board;

        public BoardEnumerator(InHwan.Board.Board board)
        {
            this.m_Board = board;
        }

        public bool IsCageTypeCell(int nRow, int nCol)
        {
            return false;
        }
    }
}