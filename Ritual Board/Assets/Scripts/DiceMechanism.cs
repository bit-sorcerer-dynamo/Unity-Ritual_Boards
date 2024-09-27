using System;
using System.Collections;
using UnityEngine;

public class DiceMechanism : MonoBehaviour
{
    public float rollForce = 10f;
    public float maxRollDuration = 5f;
    public bool isPlayersTurn = true;
    
    public EventHandler OnGeneratedNumber;

    private bool isRolling = false;
    public int RandomNumber { get; private set; }

    void Update()
    {

        if (isPlayersTurn)
        {

            if (!isRolling && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(RollDice());
            }
        }
        else
        {
            if (!isRolling)
            {
                StartCoroutine(RollDice());
            }
        }
    }

    void GenerateRandomNumber()
    {
        RandomNumber = UnityEngine.Random.Range(1, 6);
    }

    IEnumerator RollDice()
    {
        isRolling = true;

        #region Roll Dice

        Rigidbody rb = this.GetComponent<Rigidbody>();

        Vector3 randDir = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        rb.AddForce(randDir.normalized * rollForce, ForceMode.Impulse);

        Vector3 randomTorque = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * rollForce;
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        #endregion
        
        // TODO :: Get the Number on the surface of the Dice

        // Generate A Number 
        GenerateRandomNumber();
        OnGeneratedNumber?.Invoke(this, EventArgs.Empty);

        yield return new WaitForSeconds(1);

        #region Switch Entity Turn

        if (isPlayersTurn) 
            isPlayersTurn = false;
        else
            isPlayersTurn = true;

        #endregion

        isRolling = false;
    }
}
