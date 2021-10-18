using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileForeshadowing : MonoBehaviour
{
    public void Foreshadow(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
