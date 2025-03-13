using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lmao : MonoBehaviour
{
    public Dictionary<string, int> taskListWithPrio = new Dictionary<string, int>();
    //public List<string> taskList = new List<string>();

    // Start is called before the first frame update
    public void Start()
    {
        //taskList.Add("TEST");
        Debug.Log("hi");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void AddTask(string taskName, int priority)
    {
        taskListWithPrio.Add(taskName, priority);
    }
    public void RemoveTask(string taskName)
    {
        taskListWithPrio.Remove(taskName);
    }

    public void DisplayTask()
    {
        //foreach (string taskName in taskList)
        //{
        //    Debug.Log(taskName);
        //}
    }

    //public void AddTask(string taskName)
    //{
    //    taskList.Add(taskName);
    //}
    //public void RemoveTask(string taskName) 
    //{
    //    taskList.Remove(taskName);
    //}

    //public void DisplayTask()
    //{
    //    foreach (string taskName in taskList)
    //    {
    //        Debug.Log(taskName);
    //    }
    //}
}
