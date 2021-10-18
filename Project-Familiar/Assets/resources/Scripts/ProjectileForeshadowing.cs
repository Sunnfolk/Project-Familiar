using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileForeshadowing : MonoBehaviour
{
    /*private void Update()
    {
        angle = cauldron.angle;
        transform.Rotate(0,0,angle);
    }*/
    /*private void Update()
    {
        if (Keyboard.current.gKey.isPressed)
        {
            transform.rotation = quaternion.Euler(0,0,90);
        }
    }*/

    public void Foreshadow(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
