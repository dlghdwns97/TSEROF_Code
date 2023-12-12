using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public int _waypointIndex;

    public Transform GetWaypoint(int waypointIndex) //��θ� ���ϴ� ����
    {
       // Debug.Log(waypointIndex);
        _waypointIndex = waypointIndex;
        return transform.GetChild(waypointIndex); // 
    }

    public int GetNextWaypointIndex(int currentWaypointIndex) //������θ� �ҷ����� �޼���
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }

    public int SelectGetNextWaypointIndex(int currentWaypointIndex) //������θ� �ҷ����� �޼���
    {
        int nextWaypointIndex = currentWaypointIndex + 1;
        return nextWaypointIndex;
    }
    
    public int SelectGetReverseWaypointIndex(int currentWaypointIndex) //������θ� �ҷ����� �޼���
    {
        int nextWaypointIndex = currentWaypointIndex - 1;
        return nextWaypointIndex;
    }
}