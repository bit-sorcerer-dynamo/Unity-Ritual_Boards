using System;
using System.Collections.Generic;
using UnityEngine;

public class SetNextTargetBlock : MonoBehaviour
{
    public List<Transform> blocks;
    public List<EntityMovement> entities;

    public DiceMechanism dice;

    private void Start()
    {
        foreach (EntityMovement entity in entities)
        {
            entity.nextTargetBlock = blocks[UnityEngine.Random.Range(0, blocks.Count)];
        }
    }

    private void Update()
    {
        dice.OnGeneratedNumber += MoveEntityAccordingToNumberGenerated;
    }

    void MoveEntityAccordingToNumberGenerated(object sender, EventArgs e)
    {
        SetIncrementedIndexOfTargetBlock(dice.RandomNumber);
    }

    void SetIncrementedIndexOfTargetBlock(int incrementValue)
    {
        foreach (EntityMovement entity in entities)
        {
            int nextTargetBlockIndex = FindIndexOfCurrentEntityBlock(entity) + incrementValue;

            // FIXME : nextTargetIndex can be Greater than Blocks.Count
            if (nextTargetBlockIndex < blocks.Count) entity.nextTargetBlock = blocks[nextTargetBlockIndex];
            else if (nextTargetBlockIndex == blocks.Count) entity.nextTargetBlock = blocks[0];
        }
    }

    int FindIndexOfCurrentEntityBlock(EntityMovement entity)
    {
        int currentBlockIndex = 0;

        for (int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i] == entity.CurrentBlock)
            {
                currentBlockIndex = i;
            }
        }

        return currentBlockIndex;
    }
}
