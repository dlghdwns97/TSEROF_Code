using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public int _waypointIndex;

    public Transform GetWaypoint(int waypointIndex) //경로를 정하는 것음
    {
       // Debug.Log(waypointIndex);
        _waypointIndex = waypointIndex;
        return transform.GetChild(waypointIndex); // 
    }

    public int GetNextWaypointIndex(int currentWaypointIndex) //다음경로를 불러오는 메서드
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }

    public int SelectGetNextWaypointIndex(int currentWaypointIndex) //다음경로를 불러오는 메서드
    {
        int nextWaypointIndex = currentWaypointIndex + 1;
        return nextWaypointIndex;
    }
    
    public int SelectGetReverseWaypointIndex(int currentWaypointIndex) //다음경로를 불러오는 메서드
    {
        int nextWaypointIndex = currentWaypointIndex - 1;
        return nextWaypointIndex;
    }
}