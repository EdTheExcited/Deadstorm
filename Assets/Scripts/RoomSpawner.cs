using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 --> need bottom door
    //2 --> need top door
    //3 --> need left door
    //4 --> need right door
    private RoomTemplates templates;
    private int rando;
    private bool spawned = false;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.2f);
    }
    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rando = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rando], transform.position, templates.bottomRooms[rando].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rando = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rando], transform.position, templates.topRooms[rando].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rando = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rando], transform.position, templates.leftRooms[rando].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rando = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rando], transform.position, templates.rightRooms[rando].transform.rotation);
            }
            spawned = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }

    }
}
