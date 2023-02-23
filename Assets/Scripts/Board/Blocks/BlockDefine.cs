using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InHwan.Board
{
    public enum BlockType
    {
        EMPTY = 0,
        BASIC = 1,
        //2023 / 2 / 23
        MUNCHKIN = 2,
    }

    public enum BlockBreed
    {
        NA      = -1,   //Not Assigned
        BREED_0 = 0,
        BREED_1 = 1,
        BREED_2 = 2,
        BREED_3 = 3,
        BREED_4 = 4,
        BREED_MUN = 5,
    }

    public enum BlockStatus
    {
        NORMAL,                 // 평상시
        MATCH,                  // 매칭 블럭 있는 상태
        CLEAR                   // 클리어 예정 상태
    }

    public enum BlockQuestType  //블럭 클리어 발동 효과
    {
        NONE = -1,
        CLEAR_SIMPLE = 0,       // 단일 블럭 제거
        CLEAR_MUNCHKIN,
        CLEAR_HORZ = 2,         // 세로줄 블럭 제거 (내구도 -1)  ->  4 match 가로형
        CLEAR_VERT = 3,         // 가로줄 블럭 제거 -> 4 match 세로형
        CLEAR_CIRCLE = 4,       // 인접한 주변영역 블럭 제거 -> T L 매치 (3 x 3, 4 x 3)
        CLEAR_LAZER = 5,        // 지정된 블럭과 동일한 블럭 전체 제거 --> 5 match
        CLEAR_HORZ_BUF = 6,    // HORZ + CIRCLE 조합
        CLEAR_VERT_BUFF = 7,    // VERT + CIRCLE 조합    
        CLEAR_CIRCLE_BUFF = 8,  // CIRCLE + CIRCLE 조합
        CLEAR_LAZER_BUFF = 9    // LAZER + LAZER 조합
    }


    static class BlockMethod
    {
        public static bool IsSafeEqual(this Block block, Block targetBlock)
        {
            if (block == null)
                return false;

            return block.IsEqual(targetBlock);
        }
    }
}