using System;
using UnityEngine;

public class DiceMechanism : MonoBehaviour
{
    public float rollForce = 10f;
    public float maxRollDuration = 5f;
    public bool canRoll = true;
    
    public EventHandler OnGeneratedNumber;

    private bool isRolling = false;
    public int RandomNumber { get; private set; }

    void Update()
    {
        if (canRoll)
        {
            if (!isRolling && Input.GetMouseButtonDown(0))
            {
                RollDice();
            }
        }
        else
        {
            // Creature's Turn
        }
    }

    // TODO : Replace this function to return the value by 
    void GenerateRandomNumber()
    {
        RandomNumber = UnityEngine.Random.Range(1, 6);
        Debug.Log(RandomNumber);
    }

    private void RollDice()
    {
        isRolling = true;

        Rigidbody rb = this.GetComponent<Rigidbody>();

        Vector3 randDir = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        rb.AddForce(randDir.normalized * rollForce, ForceMode.Impulse);

        Vector3 randomTorque = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * rollForce;
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        isRolling = false;

        // Generate A Number 
        GenerateRandomNumber();
        OnGeneratedNumber?.Invoke(this, EventArgs.Empty);
    }
}
