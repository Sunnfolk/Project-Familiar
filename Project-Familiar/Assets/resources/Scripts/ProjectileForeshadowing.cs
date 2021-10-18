using UnityEngine;

public class ProjectileForeshadowing : MonoBehaviour
{
    public void Foreshadow(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
