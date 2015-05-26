using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServerEntity : MonoBehaviour
{

    private string ip;

    public string Ip
    {
        get { return ip; }
        set { ip = value; }
    }
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private int count;

    public int Count
    {
        get { return count; }
        set { count = value; }
    }
}
