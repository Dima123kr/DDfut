using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Text;

public class BaseOfPlayers : MonoBehaviour
{
    public static string[] Base = File.ReadAllLines(@"E:\Projects\DDfut\Assets\DATA_FILES\fut masters.csv");
    public static string[,] player_list = new string[Base.Length - 1, 12];
    public GameObject Camera;
    public static Dictionary<string, int> collection = new Dictionary<string, int>();

    void Start()
    {
        Camera.transform.position = new Vector3(3.87f, 1.29f, -11.56f);
        CreatePlayerList();
        CreateCollectionDictionary();
    }

    public static void CreatePlayerList()
    {
        for (int i = 0; i < Base.Length - 1; i++)
        {
            string[] player_list_i = Base[i + 1].Split(new string[] {";"}, StringSplitOptions.None);
            for (int n = 0; n < player_list_i.Length; n++)
            {
                player_list[i, n] = player_list_i[n];
            }
        }
    }

    public static void CreateCollectionDictionary()
    {
        string[] collectionRead = File.ReadAllLines("E:\\Projects\\DDfut\\Assets\\DATA_FILES\\Base.txt");
        for (int i = 0; i < Base.Length - 1; i++)
        {
            collection[player_list[i, 0]] = Convert.ToInt32(collectionRead[i].Split(new string[] {";"}, StringSplitOptions.None)[1]);
        }
    }
}
