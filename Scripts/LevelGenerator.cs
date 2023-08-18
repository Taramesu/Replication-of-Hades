using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject roomPrefab; // 房间的预制体
    public float roomSize; // 房间的大小
    public float roomSpacing; // 房间之间的间距
    public int maxRoomCount; // 房间的最大数量

    private Transform bossRoom; // 存储Boss房间的引用
    private Transform startRoom; // 存储起始房间的引用

    private List<Transform> generatedRooms; // 存储已生成的房间

    private void Start()
    {
        generatedRooms = new List<Transform>();

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        // 在原点生成起始房间
        Transform currentRoom = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity).transform;
        generatedRooms.Add(currentRoom);
       // startRoom = currentRoom;
        
        // 根据房间数量阈值生成房间
        for (int i = 1; i < maxRoomCount; i++)
        {         
            // 在上下左右四个方向中随机选择一个方向
            //Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
            //Vector3 randomDirection = directions[Random.Range(0, directions.Length)];

            // 计算新房间的位置
            Vector3 newRoomPosition = GetNewPosition(currentRoom.position);

            // 检测新房间位置是否与已生成的房间重叠
            Collider[] colliders = Physics.OverlapSphere(newRoomPosition, roomSize / 2f);
            if (colliders.Length > 0)
            {
                // 如果检测到重叠，跳过当前循环
                i --;
                continue;
            }

            // 在新位置生成房间
            //Transform newRoomTransform = Instantiate(roomPrefab, newRoomPosition, Quaternion.identity).transform;
            //generatedRooms.Add(newRoomTransform);
           currentRoom.position =   GenerateRoom(newRoomPosition);
            
        }
        SetStartEnd();
    }
    private Vector3 GetNewPosition(Vector3 currentPos)
    {
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 randomDirection = directions[Random.Range(0, directions.Length)];

        // 计算新房间的位置
        Vector3 newRoomPosition = currentPos + randomDirection * (roomSize + roomSpacing);
        return newRoomPosition;
    }
    private Vector3 GenerateRoom(Vector3 position)
    {
        // 在指定位置生成房间
        Transform newRoomTransform = Instantiate(roomPrefab, position, Quaternion.identity).transform;
        generatedRooms.Add(newRoomTransform);
        return newRoomTransform.position;
    }

    private void SetStartEnd()
    {
        // 找到两个相距最远的房间，一个作为起点，一个作为Boss房间
        float maxDistance = 0f;
        foreach (Transform roomA in generatedRooms)
        {
            foreach (Transform roomB in generatedRooms)
            {
                if (roomA != roomB)
                {
                    float distance = Vector3.Distance(roomA.position, roomB.position);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        startRoom = roomA;
                        bossRoom = roomB;
                    }
                }
            }
        }

        // 在起点和Boss房间中进行标记或其他操作
        if (startRoom != null)
        {
            // 在起点房间进行标记
            startRoom.GetComponent<Renderer>().material.color = Color.green;
        }
        if (bossRoom != null)
        {
            // 在Boss房间进行标记
            bossRoom.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}

