using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset = new Vector3(0f, 0f, 10.80f);
    [SerializeField] Vector3 playerOffset = new Vector3(0f, 0f, 4.2f);

    private RoomGenerator roomGenerator;
    public bool locked = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (locked)
            return;
        
        if (other.gameObject.GetComponentInParent<Player>() != null)
        {
            Player player = other.gameObject.GetComponentInParent<Player>();
            player.gameObject.transform.position += playerOffset;
            Camera.main.transform.position += cameraOffset;
            roomGenerator.UpdateCurrentRoom();
            //other.GetComponent<Player>().weapon
        }
    }

    public void SetRoomGenerator(RoomGenerator roomGenerator)
    {
        this.roomGenerator = roomGenerator;
    }
}
