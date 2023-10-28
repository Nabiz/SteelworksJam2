using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    public static RoomGenerator Instance;
    [SerializeField] private int roomCount = 15;
    [SerializeField] private int unitLenght = 1;
    private float xDimension;
    private float zDimension;

    [SerializeField] private List<GameObject> roomPrefabs;
    [SerializeField] private List<Vector3> possibleRoomPosition;
    private List<Vector3> occupiedRoomPositions = new List<Vector3>();

    private List<GameObject> roomList = new List<GameObject>();
     
    public Room currentRoom;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Generate(List<Prop> propsList)
    {
        xDimension = 19.20f * unitLenght;
        zDimension = 10.80f * unitLenght;

        GenerateRoom(roomPrefabs[0], Vector3.zero);
        currentRoom = roomList[0].GetComponent<Room>();

        Debug.Log($"catched {propsList.Count} prompts");
        List<GameObject> enemiesPrefabs = new List<GameObject>();
        foreach (Prop prop in SelectRandomProps(propsList))
        {
            enemiesPrefabs.Add(prop.enemyPrefab);
        }
        currentRoom.SpawnEnemies(enemiesPrefabs);

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
        newRoom.GetComponent<Room>().doorUp.GetComponent<Door>().SetRoomGenerator(this);
        newRoom.GetComponent<Room>().doorDown.GetComponent<Door>().SetRoomGenerator(this);
        newRoom.GetComponent<Room>().doorRight.GetComponent<Door>().SetRoomGenerator(this);
        newRoom.GetComponent<Room>().doorLeft.GetComponent<Door>().SetRoomGenerator(this);

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

    public void UpdateCurrentRoom()
    {
        float cameraPosX = Camera.main.transform.position.x;
        float cameraPosZ = Camera.main.transform.position.z;
        foreach (GameObject room in roomList)
        {
            float roomPosX = room.transform.position.x;
            float roomPosZ = room.transform.position.z;

            if((System.Math.Abs(cameraPosX-roomPosX) < 0.1f) && (System.Math.Abs(cameraPosZ - roomPosZ) < 0.1f))
            {
                currentRoom = room.GetComponent<Room>();
            }
        }
    }
    
    List<Prop> SelectRandomProps(List<Prop> props)
    {
        if (props == null || props.Count == 0)
            return new List<Prop>();
        
        List<Prop> propsList = new List<Prop>(props);
        List<Prop> selectedElements = new List<Prop>();
        
        int numberOfElementsToSelect = Random.Range(1, propsList.Count + 1);
        for (int i = 0; i < numberOfElementsToSelect; i++)
        {
            int randomIndex = Random.Range(0, propsList.Count - 1);
            selectedElements.Add(propsList[randomIndex]);
            propsList.RemoveAt(randomIndex);
        }
        
        return selectedElements;
    }
    
    public void Cleanup()
    {
        foreach (GameObject room in roomList)
        {
            Destroy(room);
        }
        roomList.Clear();
        possibleRoomPosition.Clear();
        occupiedRoomPositions.Clear();
    }
}
