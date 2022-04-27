using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door

	private RoomTemplates templates;
	private int rand;
	private System.Action roomSpawn = null;
	public bool spawned = false;

	public float waitTime = 4f;

    void Start()
    {
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		StartCoroutine(Spawn(2.0f));
    }

	private IEnumerator Spawn(float waitTime)
	{
		while (true)
		{
			if(spawned == false)
			{
				if(openingDirection == 1)
				{
					//Bottom 号狽 持失
					rand = Random.Range(0, templates.bottomRooms.Count);
					Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				} else if(openingDirection == 2)
				{
					//Top 号狽 持失
					rand = Random.Range(0, templates.topRooms.Count);
					Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				} else if(openingDirection == 3)
				{
					//Left 号狽 持失
					rand = Random.Range(0, templates.leftRooms.Count);
					Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				} else if(openingDirection == 4)
				{
					//Right 号狽 持失
					rand = Random.Range(0, templates.rightRooms.Count);
					Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				}
				spawned = true;
			}
			yield return new WaitForSeconds(waitTime);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				if (null != templates){
					Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
					Destroy(gameObject);
				}
			} 
			spawned = true;
		}		
	}
}
