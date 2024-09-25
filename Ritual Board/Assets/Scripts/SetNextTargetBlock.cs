using System.Collections.Generic;
using UnityEngine;

public class SetNextTargetBlock : MonoBehaviour
{
    public List<Transform> blocks;
    public List<EntityMovement> entities;

    private void Start()
    {
        foreach (EntityMovement entity in entities)
        {
            entity.nextTargetBlock = blocks[Random.Range(0, blocks.Count)];
        }

        InvokeRepeating("SetIncrementedIndexOfTargetBlock", 2f, 1f);
    }

    private void Update()
    {

    }

    void SetIncrementedIndexOfTargetBlock()
    {
        foreach (EntityMovement entity in entities)
        {
            int nextTargetBlockIndex = FindIndexOfCurrentEntityBlock(entity) + 1;

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
