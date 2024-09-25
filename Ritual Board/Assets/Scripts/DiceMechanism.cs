using UnityEngine;

public class DiceMechanism : MonoBehaviour
{
    public float rollForce = 10f;
    public float maxRollDuration = 5f;

    private bool isRolling = false;

    void Update()
    {
        if(!isRolling && Input.GetMouseButtonDown(0))
        {
            RollDice();
        }
    }

    private void RollDice()
    {
        isRolling = true;

        Rigidbody rb = this.GetComponent<Rigidbody>();

        Vector3 randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 1f), Random.Range(-1f, 1f));
        rb.AddForce(randDir.normalized * rollForce, ForceMode.Impulse);

        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * rollForce;
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        isRolling = false;
    }
}
