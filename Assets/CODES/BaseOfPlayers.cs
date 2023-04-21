using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Text;

public class BaseOfPlayers : MonoBehaviour
{
    public TextAsset TextAssetData;
    public Dictionary<string, int> collection = new Dictionary<string, int>();
    public GameObject Camera;

    [System.Serializable]
    public class Player
    {
        public string name;
        public string position;
        public string country;
        public string club;
        public string rating0;
        public string rating1;
        public string rating2;
        public string rating3;
        public string rating4;
        public string rating5;
        public string rating6;
        public string tip;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    void Start()
    {
        ReadCSV();
        CreateCollectionDictionary();
        StartCamera();
    }

    public void CreateCollectionDictionary()
    {
        string[] collectionRead = File.ReadAllLines("C:\\Users\\Дима\\Documents\\GitHub\\DDfut\\Assets\\DATA_FILES\\Base.txt");
        for (int i = 0; i < myPlayerList.player.Length; i++)
        {
            collection[myPlayerList.player[i].name] = Convert.ToInt32(collectionRead[i].Split(new string[] {";"}, StringSplitOptions.None)[1]);
        }
    }

    public void ReadCSV()
    {
        string[] dt = TextAssetData.text.Split(new string[] {";", "\n"}, StringSplitOptions.None);
        int size = dt.Length / 12 - 1;
        myPlayerList.player = new Player[size];

        for (int i = 0; i < size; i++)
        {
            myPlayerList.player[i] = new Player();
            myPlayerList.player[i].name = dt[12 * (i + 1)];
            myPlayerList.player[i].position = dt[12 * (i + 1) + 1];
            myPlayerList.player[i].country = dt[12 * (i + 1) + 2];
            myPlayerList.player[i].club = dt[12 * (i + 1) + 3];
            myPlayerList.player[i].rating0 = dt[12 * (i + 1) + 4];
            myPlayerList.player[i].rating1 = dt[12 * (i + 1) + 5];
            myPlayerList.player[i].rating2 = dt[12 * (i + 1) + 6];
            myPlayerList.player[i].rating3 = dt[12 * (i + 1) + 7];
            myPlayerList.player[i].rating4 = dt[12 * (i + 1) + 8];
            myPlayerList.player[i].rating5 = dt[12 * (i + 1) + 9];
            myPlayerList.player[i].rating6 = dt[12 * (i + 1) + 10];
            myPlayerList.player[i].tip = dt[12 * (i + 1) + 11];
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
            number = UnityEngine.Random.Range(0, myPlayerList.player.Length);
            while (numbers.Contains(number))
            {
                number = UnityEngine.Random.Range(0, myPlayerList.player.Length);
            }
            numbers[i] = number;
        }
        string[] names = new string[9];
        for (int i = 0; i < 9; i++)
        {
            names[i] = myPlayerList.player[numbers[i]].name;
            count = collection[myPlayerList.player[numbers[i]].name];
            collection.Remove(myPlayerList.player[numbers[i]].name);
            collection[myPlayerList.player[numbers[i]].name] = count + 1;
            count = 0;
            File.Delete("C:\\Users\\Дима\\Documents\\GitHub\\DDfut\\Assets\\Base.txt");
            for (int n = 0; n < myPlayerList.player.Length; n++)
            {
                File.AppendAllText("C:\\Users\\Дима\\Documents\\GitHub\\DDfut\\Assets\\Base.txt", $"{myPlayerList.player[n].name};{collection[myPlayerList.player[n].name]}\n");
            }
        }
        return names;
    }
}
