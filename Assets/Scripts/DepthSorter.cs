using UnityEngine;

public class DepthSorter : MonoBehaviour
{
    public Transform SortingTarget;
    float baseZ;
    // Start is called before the first frame update
    void Start()
    {
        baseZ = transform.position.z;
        if (SortingTarget == null)
        {
            SortingTarget = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.z = baseZ + SortingTarget.position.y / 100;
        transform.position = position;
    }
}
