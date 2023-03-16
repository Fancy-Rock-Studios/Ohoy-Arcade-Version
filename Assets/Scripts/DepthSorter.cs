using UnityEngine;

public class DepthSorter : MonoBehaviour
{
    float baseZ;
    // Start is called before the first frame update
    void Start()
    {
        baseZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.z = baseZ + transform.position.y / 100;
        transform.position = position;
    }
}
