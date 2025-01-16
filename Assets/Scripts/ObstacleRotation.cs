using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    private float rotZ;
    public float RotationSpeed;
    public bool Clockwise;


    void Update()
    {
        if(Clockwise)
        {
            rotZ -= Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotZ += Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
