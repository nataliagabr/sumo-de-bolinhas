using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    public Vector3 offset = new Vector3(0, 8, -8);

    void LateUpdate()
    {
        if(target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if(player != null)
            {
                target = player.transform;
            }
            else
            {
                return;
            }
        }

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
