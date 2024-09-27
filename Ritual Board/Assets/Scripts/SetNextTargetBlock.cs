using System;
using System.Collections.Generic;
using UnityEngine;

public class SetNextTargetBlock : MonoBehaviour
{
    public List<Transform> blocks;
    public List<EntityMovement> entities;

    public DiceMechanism dice;

    private const string PLAYER = "Player";
    private const string CREATURE = "Creature";

    private void Start()
    {
        // Give a Random Position to Both The Entities
        foreach (EntityMovement entity in entities)
        {
            entity.nextTargetBlock = blocks[UnityEngine.Random.Range(0, blocks.Count)];
        }
    }

    private void Update()
    {
        // Calls the MoveEntityAccordingToNumberGenerated Function when The Dice is Rolled 
        dice.OnGeneratedNumber += MoveEntityAccordingToNumberGenerated;
    }

    // Handles Entity Movement
    void MoveEntityAccordingToNumberGenerated(object sender, EventArgs e)
    {
        if (dice.isPlayersTurn) 
            SetIncrementedIndexOfTargetBlock(dice.RandomNumber, PLAYER);
        else 
            SetIncrementedIndexOfTargetBlock(dice.RandomNumber, CREATURE);
    }

    // Moves a Particular Entity to the Generated Target Block
    void SetIncrementedIndexOfTargetBlock(int incrementValue, string currentTurn)
    {
        foreach (EntityMovement entity in entities)
        {
            if(entity.name == currentTurn)
            {
                int nextTargetBlockIndex = FindIndexOfCurrentEntityBlock(entity) + incrementValue;

                if (nextTargetBlockIndex > blocks.Count) nextTargetBlockIndex = nextTargetBlockIndex - blocks.Count;
                else if (nextTargetBlockIndex == blocks.Count) nextTargetBlockIndex = 0;

                entity.nextTargetBlock = blocks[nextTargetBlockIndex];
            }
        }
    }

    // Finds the current Index of an Entity
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
