using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    //Variables
    
    public TextMeshProUGUI stacktext;

    public TextMeshProUGUI queuetext;

    public InputActionReference interactstack;

    public InputActionReference interactqueue;

    private string[] colors = new string[7] {"orange","blue","red","chartruse","green","black","indigo"};

    //make a list that is empty and will hold strings
    public List<string> colorList = new List<string>();

    //Make a stack of strings
    //STACKS are LIFO (Last in First out)
    private Stack<string> colorStack = new Stack<string>();


    private Stack<string> colorStackfromList = new Stack<string>();


    //Make a queue of strings
    //QUEUES are FIFO (First in First out)
    private Queue<string> colorQueue = new Queue<string>();

    private Queue<string> colorQueuefromList = new Queue<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //add the strings from the array to the list
        colorList.AddRange(colors);
        
        //add the strings from the array to our stack
        //for loop created from an array
        for(int i = 0; i < colors.Length; i++)
        {
            //add the string from the location of the array that matches our number
            colorStack.Push(colors[i]);
        }
        //print the number of strings in my stack
        Debug.Log(colorStack.Count);

        //add the strings from the list to the stack
        //for loop from a list
        for(int i = 0; i < colorList.Count; i++)
        {
            //add the strings to the stack by loction or count number
            colorStackfromList.Push(colorList[i]);
        }

        //add the strings from the array to the queue
        //foreach string in our array add it to the queue
        foreach(string s in colors)
        {
            colorQueue.Enqueue(s);
        }

        //add all the strings from the list to the queue
        //foreach string in the list add it to the queue
        foreach(string s in colorList)
        {
            colorQueuefromList.Enqueue(s);
        }
     

    }

    // Update is called once per frame
    void Update()
    {
        //make the texts say the top position of stack and queue
        if (interactstack.action.WasPressedThisFrame() && colorStack.Count > 0 )
        {
            stacktext.text = colorStack.Pop();
        }else if(interactqueue.action.WasPressedThisFrame() && colorQueue.Count > 0)
        {
            queuetext.text = colorQueue.Dequeue();
        }
    }
}