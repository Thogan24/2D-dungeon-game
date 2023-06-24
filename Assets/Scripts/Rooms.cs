using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public int[,] rooms;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void generateFloor(int roomCount)
    {
        

        // [room #, properties]
        rooms = new int[roomCount, 3];

        rooms[0, 0] = 0;
        rooms[0, 1] = 0;

        rooms[0, 2] = 0;

        
    }

    void roomPath(int previousX, int previousY, int currentX, int currentY, int roomCountLeft, int currentRoom, int originalRoomCount)
    {


        roomCheckSurroundingRooms(currentX, currentY, currentRoom);

        // Look ahead room

    }


    bool[] roomCheckSurroundingRooms(int currentX, int currentY, int currentRoom)
    {
        bool roomLeft = false;
        bool roomRight = false;
        bool roomDown = false;
        bool roomTop = false;
        for (int i = 0; i < currentRoom; i++)
        {
            // room left don't exist
            if (rooms[i, 0] != currentX - 1 && rooms[i, 1] != currentY)
            {
                roomLeft = true;
            }
            // room right don't exist
            if (rooms[i, 0] != currentX + 1 && rooms[i, 1] != currentY)
            {
                roomRight = true;
            }
            // room down don't exist
            if (rooms[i, 0] != currentX && rooms[i, 1] != currentY - 1)
            {
                roomDown = true;
            }
            // room up don't exist
            if (rooms[i, 0] != currentX && rooms[i, 1] != currentY + 1)
            {
                roomTop = true;
            }

        }
        bool[] j = {roomLeft, roomRight, roomDown, roomTop};

        return j;
    }
}
