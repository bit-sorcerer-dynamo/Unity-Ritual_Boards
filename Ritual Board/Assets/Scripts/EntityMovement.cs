using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [Header("Movement & Lerping"), Space(10)]
    public bool canMoveToNextBlock = false;

    public float repeatRate;
    public float interpolateForce = 5f;

    [HideInInspector] public Transform nextTargetBlock;
    private Transform targetBlockSpawnPosition;
    
    public Transform CurrentBlock { get; private set; }

    void Update()
    {
        if (canMoveToNextBlock)
        {
            targetBlockSpawnPosition = nextTargetBlock.GetChild(0);
            MoveToNextBlock(targetBlockSpawnPosition);
        }
    }

    private void MoveToNextBlock(Transform targetBlock)
    {
        transform.position = Vector3.Lerp(transform.position, targetBlock.position, interpolateForce * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.name.Contains("Block"))
        {
            CurrentBlock = collision.transform;
        }
    }
}
