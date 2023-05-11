using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Text;

public class BaseOfPlayers : MonoBehaviour
{
    public GameObject Camera;
    string Base_ = File.ReadAllText("C:\\Projects\\DDfut\\Assets\\DATA_FILES\\fut masters.txt");
    public Dictionary<string, int> collection = new Dictionary<string, int>();
    string[] dt = Base_.text.Split(new string[] {"\n"}, StringSplitOptions.None);
    string[,] player_list = new string[dt.Length - 1, 12];

    void Start()
    {
        for (int i = 0; i < dt.Length - 1; i++)
        {
            string[] player_list_i = dt[i + 1].Split(new string[] {";"}, StringSplitOptions.None);
            for (int n = 0; n < player_list_i.Length; n++)
            {
                player_list[i, n] = player_list_i[n];
            }
        }
        CreateCollectionDictionary();
        StartCamera();
        RandomCards();
    }

    public void CreateCollectionDictionary()
    {
        string[] collectionRead = File.ReadAllLines("C:\\Projects\\DDfut\\Assets\\DATA_FILES\\Base.txt");
        for (int i = 0; i < player_list.Length / 12; i++)
        {
            collection[player_list[i, 0]] = Convert.ToInt32(collectionRead[i].Split(new string[] {";"}, StringSplitOptions.None)[1]);
        }
    }

    public void StartCamera()
    {
        Camera.transform.position = new Vector3(3.87f, 1.29f, -11.56f);
    }

    public string[] RandomCards()
    {
        int[] numbers = new int[9];
        int number;
        int count;
        for (int i = 0; i < 9; i++)
        {
            number = UnityEngine.Random.Range(0, player_list.Length);
            while (numbers.Contains(number))
            {
                number = UnityEngine.Random.Range(0, player_list.Length);
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
            File.Delete("C:\\Projects\\DDfut\\Assets\\Base.txt");
            for (int n = 0; n < player_list.Length; n++)
            {
                File.AppendAllText("C:\\Projects\\DDfut\\Assets\\Base.txt", $"{player_list[n, 0]};{collection[player_list[n, 0]]}\n");
            }
        }
        return names;
    }
}
