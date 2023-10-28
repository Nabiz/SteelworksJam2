using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    [SerializeField] private int roomCount = 15;
    [SerializeField] private int unitLenght = 1;
    private float xDimension;
    private float zDimension;

    [SerializeField] private List<GameObject> roomPrefabs;
    [SerializeField] private List<Vector3> possibleRoomPosition;
    private List<Vector3> occupiedRoomPositions = new List<Vector3>();

    private List<GameObject> roomList = new List<GameObject>();

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        xDimension = 19.20f * unitLenght;
        zDimension = 10.80f * unitLenght;


        GenerateRoom(roomPrefabs[0], Vector3.zero);

        for(int i=0; i < roomCount; i++)
        {
            GameObject randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
            int randomRoomPositionIndex = Random.Range(0, possibleRoomPosition.Count);
            Vector3 randomRoomPosition = possibleRoomPosition[randomRoomPositionIndex];
            possibleRoomPosition.RemoveAt(randomRoomPositionIndex);
            GenerateRoom(randomRoom, randomRoomPosition);
        }
        RemoveDoors();
    }

    private void GenerateRoom(GameObject room, Vector3 roomPosition)
    {
        GameObject newRoom = Instantiate(room, roomPosition, Quaternion.identity, transform);
        roomList.Add(newRoom);
        occupiedRoomPositions.Add(roomPosition);
        Vector3[] vector3s = { roomPosition + Vector3.forward * zDimension,
                                roomPosition + Vector3.back * zDimension,
                                roomPosition + Vector3.right * xDimension,
                                roomPosition + Vector3.left * xDimension,
                            };
        foreach(Vector3 vector in vector3s)
        {
            if (!(occupiedRoomPositions.Contains(vector) || possibleRoomPosition.Contains(vector)))
            {
                if(possibleRoomPosition.Count < 5 || Random.Range(0.0f, 1.0f) < 0.25f)
                {
                    possibleRoomPosition.Add(vector);
                }
            }
        }
    }

    private void RemoveDoors()
    {
        foreach(GameObject roomObject in roomList)
        {
            Room room = roomObject.GetComponent<Room>();
            if (occupiedRoomPositions.Contains(room.transform.position + Vector3.forward * zDimension))
            {
                room.doorUp.SetActive(true);
            }
            if (occupiedRoomPositions.Contains(room.transform.position + Vector3.back * zDimension))
            {
                room.doorDown.SetActive(true);
            }
            if (occupiedRoomPositions.Contains(room.transform.position + Vector3.right * xDimension))
            {
                room.doorRight.SetActive(true);
            }
            if (occupiedRoomPositions.Contains(room.transform.position + Vector3.left * xDimension))
            {
                room.doorLeft.SetActive(true);
            }
        }
    }
}
