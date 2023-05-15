using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Text;

public class OpenFreePack : MonoBehaviour
{
    static string[] Base = BaseOfPlayers.Base;
    static string[,] player_list = BaseOfPlayers.player_list;
    static Dictionary<string, int> collection = BaseOfPlayers.collection;

    public void Start()
    {
        BaseOfPlayers.CreatePlayerList();
        BaseOfPlayers.CreateCollectionDictionary();
    }
    
    public void OnMouseDown()
    {
        
    }

    public string[] RandomCards()
    {
        int[] numbers = new int[9];
        int number;
        int count;
        for (int i = 0; i < 9; i++)
        {
            number = UnityEngine.Random.Range(0, Base.Length);
            while (numbers.Contains(number))
            {
                number = UnityEngine.Random.Range(0, Base.Length);
            }
            numbers[i] = number;
        }
        string[] names = new string[9];
        for (int i = 0; i < 9; i++)
        {
            names[i] = player_list[numbers[i], 0];
            count = collection[player_list[numbers[i], 0]];
            collection.Remove(player_list[numbers[i], 0]);
            collection[player_list[numbers[i], 0]] = count + 1;
            count = 0;
            Debug.Log(names[i]);
            File.Delete("E:\\Projects\\DDfut\\Assets\\DATA_FILES\\Base.txt");
            for (int n = 0; n < Base.Length - 1; n++)
            {
                File.AppendAllText("E:\\Projects\\DDfut\\Assets\\DATA_FILES\\Base.txt", $"{player_list[n, 0]};{collection[player_list[n, 0]]}\n");
            }
        }
        return names;
    }
}
