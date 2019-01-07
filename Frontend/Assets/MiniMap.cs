using Gamekit3D;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform player = null;

    public void Update()
    {
        if (player == null && PlayerController.Mine != null)
            player = PlayerController.Mine.transform;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }

    }
}
