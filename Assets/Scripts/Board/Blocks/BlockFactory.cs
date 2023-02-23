using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InHwan.Board
{
    public static class BlockFactory
    {
        public static Block SpawnBlock(BlockType blockType)
        {
            Block block = new Block(blockType);

            //Set Breed
            if(blockType == BlockType.BASIC)
                block.breed = (BlockBreed)UnityEngine.Random.Range(0, 5);
            else if(blockType == BlockType.EMPTY)
                block.breed = BlockBreed.NA;

            return block;
        }
    }
}