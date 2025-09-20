using UnityEngine;

public class DoorFunc : MonoBehaviour
{
    private GameObject[] door;
    private DoorScript doorScript;

    void Awake()
    {
        door = GameObject.FindGameObjectsWithTag("Door");
    }

    public void UnlockDoors()
    {
        for (int i = 0; i < door.Length; i++)
        {
            doorScript = door[i].GetComponent<DoorScript>();
            doorScript.UnlockDoor();
        }
    }

    public void LockDoors()
    {
        for (int i = 0; i < door.Length; i++)
        {
            doorScript = door[i].GetComponent<DoorScript>();
            doorScript.LockDoor();
        }
    }
}