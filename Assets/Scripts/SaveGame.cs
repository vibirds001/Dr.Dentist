using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveGame : MonoBehaviour
{
    public static void WriteString(string board)
    {
        string path = Application.persistentDataPath + "/test.txt";
       // string path = "Assets/SaveFile/SaveData.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(board);
        writer.Close();
        StreamReader reader = new StreamReader(path);
        //Print the text from the file
  //      Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
    public static string ReadString(string path )
    {
       // string path = "Assets/SaveFile/SaveData.txt";
        //Read the text from directly from the test.txt file
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string str = reader.ReadToEnd().ToString();
            reader.Close();
    
            return str;
        }
        else
        {
            return null;
        }
    }

    
    public static void DeleteSavedFile()
    {
      
        File.Delete(Application.persistentDataPath + "/test.txt");
       
    }

}

