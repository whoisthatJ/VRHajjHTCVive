using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClicked : MonoBehaviour
{
    [SerializeField] FittingRoomManager manager;
    [SerializeField] private int doorID; 
    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        manager.DoorClicked(doorID);
        
    }
}
