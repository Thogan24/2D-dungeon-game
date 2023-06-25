using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public int[,] rooms;
    public int totalCurrentRoom;

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

        // X
        rooms[0, 0] = 0;
        // Y
        rooms[0, 1] = 0;

        // Objects Generated
        rooms[0, 2] = 0;

        roomPath(0, 0, roomCount, 0);
    }

    void roomPath(int currentX, int currentY, int roomCountLeft, int currentRoom)
    {
        if (roomCountLeft > 0)
        {
            int[] chances = { 10, 10, 10, 10 };

            // May not need to do this every time
            bool[] currentRoomCheck = roomCheckSurroundingRooms(currentX, currentY, currentRoom);



            // Left
            if (currentRoomCheck[0] == false)
            {
                bool[] leftRoomCheck = roomCheckSurroundingRooms(currentX - 1, currentY, currentRoom);
                for (int i = 0; i < leftRoomCheck.Length; i++)
                {
                    if (leftRoomCheck[i] == true)
                    {
                        chances[0] -= 2;
                    }
                }
                chances[0] += 2;
            }

            // Right
            if (currentRoomCheck[0] == false)
            {
                bool[] rightRoomCheck = roomCheckSurroundingRooms(currentX + 1, currentY, currentRoom);
                for (int i = 0; i < rightRoomCheck.Length; i++)
                {
                    if (rightRoomCheck[i] == true)
                    {
                        chances[1] -= 2;
                    }
                }
                chances[1] += 2;
            }

            // Down
            if (currentRoomCheck[0] == false)
            {
                bool[] downRoomCheck = roomCheckSurroundingRooms(currentX, currentY - 1, currentRoom);
                for (int i = 0; i < downRoomCheck.Length; i++)
                {
                    if (downRoomCheck[i] == true)
                    {
                        chances[2] -= 2;
                    }
                }
                chances[2] += 2;
            }

            // Up
            if (currentRoomCheck[0] == false)
            {
                bool[] upRoomCheck = roomCheckSurroundingRooms(currentX, currentY + 1, currentRoom);
                for (int i = 0; i < upRoomCheck.Length; i++)
                {
                    if (upRoomCheck[i] == true)
                    {
                        chances[3] -= 2;
                    }
                }
                chances[3] += 2;
            }




            int roomsGenerated = 0;
            bool[] roomsGeneratedList = new bool[4];
            if (Random.Range(1, 11) < chances[0])
            {
                roomsGeneratedList[0] = true;
                roomsGenerated++;
            }
            if (Random.Range(1, 11) < chances[1])
            {
                roomsGeneratedList[1] = true;
                roomsGenerated++;
            }
            if (Random.Range(1, 11) < chances[2])
            {
                roomsGeneratedList[2] = true;
                roomsGenerated++;
            }
            if (Random.Range(1, 11) < chances[3])
            {
                roomsGeneratedList[3] = true;
                roomsGenerated++;
            }



            if(roomsGeneratedList[0] == true)
            {
                generateRoom(currentX - 1, currentY, currentRoom);

                roomPath(currentX - 1, currentY, (roomCountLeft - roomsGenerated) / roomsGenerated, totalCurrentRoom);
                totalCurrentRoom++;
            }

            if (roomsGeneratedList[1] == true)
            {
                generateRoom(currentX + 1, currentY, currentRoom);

                roomPath(currentX + 1, currentY, (roomCountLeft - roomsGenerated) / roomsGenerated, totalCurrentRoom);
                totalCurrentRoom++;
            }

            if (roomsGeneratedList[2] == true)
            {
                generateRoom(currentX - 1, currentY, currentRoom);

                roomPath(currentX - 1, currentY, (roomCountLeft - roomsGenerated) / roomsGenerated, totalCurrentRoom);
                totalCurrentRoom++;
            }

            if (roomsGeneratedList[3] == true)
            {
                generateRoom(currentX - 1, currentY, currentRoom);

                roomPath(currentX - 1, currentY, (roomCountLeft - roomsGenerated) / roomsGenerated + (roomCountLeft - roomsGenerated) % roomsGenerated, totalCurrentRoom);
                totalCurrentRoom++;
            }


        }

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

    void generateRoom(int x, int y, int currentRoom)
    {
        // X
        rooms[currentRoom, 0] = x;
        // Y
        rooms[currentRoom, 1] = y;

        // Objects Generated
        rooms[currentRoom, 2] = 0;
    }
}
