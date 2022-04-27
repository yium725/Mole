using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
	public List<GameObject> bottomRooms;
	public List<GameObject> topRooms;
	public List<GameObject> leftRooms;
	public List<GameObject> rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;
	public int roomCount;
	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;

	void Start()
	{
		recurciveCall(ref bottomRooms);
		recurciveCall(ref topRooms);
		recurciveCall(ref leftRooms);
		recurciveCall(ref rightRooms);
	}

	void recurciveCall(ref List<GameObject>roomList)
	{
		if (roomList.Count <= roomCount)
		{
			return;
		}
		int lastIdx = roomList.Count - 1 ;
		roomList.RemoveAt(lastIdx);
		recurciveCall(ref roomList);
	}

    // Update is called once per frame
    void Update()
    {
		if(waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if(i == rooms.Count-1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		}
		else
		{
			waitTime -= Time.deltaTime;
		}  
    }
}
