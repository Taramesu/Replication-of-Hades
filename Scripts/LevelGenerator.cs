using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject roomPrefab; // �����Ԥ����
    public float roomSize; // ����Ĵ�С
    public float roomSpacing; // ����֮��ļ��
    public int maxRoomCount; // ������������

    private Transform bossRoom; // �洢Boss���������
    private Transform startRoom; // �洢��ʼ���������

    private List<Transform> generatedRooms; // �洢�����ɵķ���

    private void Start()
    {
        generatedRooms = new List<Transform>();

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        // ��ԭ��������ʼ����
        Transform currentRoom = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity).transform;
        generatedRooms.Add(currentRoom);
       // startRoom = currentRoom;
        
        // ���ݷ���������ֵ���ɷ���
        for (int i = 1; i < maxRoomCount; i++)
        {         
            // �����������ĸ����������ѡ��һ������
            //Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
            //Vector3 randomDirection = directions[Random.Range(0, directions.Length)];

            // �����·����λ��
            Vector3 newRoomPosition = GetNewPosition(currentRoom.position);

            // ����·���λ���Ƿ��������ɵķ����ص�
            Collider[] colliders = Physics.OverlapSphere(newRoomPosition, roomSize / 2f);
            if (colliders.Length > 0)
            {
                // �����⵽�ص���������ǰѭ��
                i --;
                continue;
            }

            // ����λ�����ɷ���
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

        // �����·����λ��
        Vector3 newRoomPosition = currentPos + randomDirection * (roomSize + roomSpacing);
        return newRoomPosition;
    }
    private Vector3 GenerateRoom(Vector3 position)
    {
        // ��ָ��λ�����ɷ���
        Transform newRoomTransform = Instantiate(roomPrefab, position, Quaternion.identity).transform;
        generatedRooms.Add(newRoomTransform);
        return newRoomTransform.position;
    }

    private void SetStartEnd()
    {
        // �ҵ����������Զ�ķ��䣬һ����Ϊ��㣬һ����ΪBoss����
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

        // ������Boss�����н��б�ǻ���������
        if (startRoom != null)
        {
            // ����㷿����б��
            startRoom.GetComponent<Renderer>().material.color = Color.green;
        }
        if (bossRoom != null)
        {
            // ��Boss������б��
            bossRoom.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}

