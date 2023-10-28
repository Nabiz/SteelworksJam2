using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset = new Vector3(0f, 0f, 10.80f);
    [SerializeField] Vector3 playerOffset = new Vector3(0f, 0f, 4.2f);

    private RoomGenerator roomGenerator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.position += playerOffset;
            Camera.main.transform.position += cameraOffset;
            roomGenerator.UpdateCurrentRoom();
            //if (other.GetComponent<Player>().weapon
        }
    }

    public void SetRoomGenerator(RoomGenerator roomGenerator)
    {
        this.roomGenerator = roomGenerator;
    }
}
