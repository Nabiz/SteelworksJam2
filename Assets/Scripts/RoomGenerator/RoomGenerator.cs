using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    [SerializeField] private int unitLenght = 1;
    private int xDimension;
    private int zDimension;

    [SerializeField] private List<GameObject> roomPrefabs;
    [SerializeField] private List<Vector3> possibleRoomPosition;
    private List<Vector3> occupiedRoomPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        xDimension = 16 * unitLenght;
        zDimension = 9 * unitLenght;


        GenerateRoom(roomPrefabs[0], Vector3.zero);

        for(int i=0; i < 15; i++)
        {
            GameObject randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
            int randomRoomPositionIndex = Random.Range(0, possibleRoomPosition.Count);
            Vector3 randomRoomPosition = possibleRoomPosition[randomRoomPositionIndex];
            possibleRoomPosition.RemoveAt(randomRoomPositionIndex);
            GenerateRoom(randomRoom, randomRoomPosition);
        }

        foreach(Vector3 vec in occupiedRoomPositions)
        {
            Debug.Log(vec);
        }
    }

    private void GenerateRoom(GameObject room, Vector3 roomPosition)
    {
        GameObject newRoom = Instantiate(room, roomPosition, Quaternion.identity, transform);
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
            else
            {
                Debug.Log("DUPA");
            }
        }
    }
}
