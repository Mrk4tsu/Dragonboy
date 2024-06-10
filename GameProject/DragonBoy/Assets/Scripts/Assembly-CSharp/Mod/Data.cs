using Mod.ModHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Mod
{
    internal class Data
    {
        internal static readonly string dataPath = Path.Combine(Utils.GetRootDataPath(), "CommonModData");
        internal static int LoadDataInt(string name, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Open);
            byte[] array = new byte[4];
            fileStream.Read(array, 0, 4);
            fileStream.Close();
            return BitConverter.ToInt32(array, 0);
        }

        internal static bool LoadDataBool(string name, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Open);
            byte[] array = new byte[1];
            fileStream.Read(array, 0, 1);
            fileStream.Close();
            return array[0] == 1;
        }

        internal static string LoadDataString(string name, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            fileStream.Close();
            return result;
        }

        internal static float LoadDataFloat(string name, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Open);
            byte[] array = new byte[4];
            fileStream.Read(array, 0, 4);
            fileStream.Close();
            return BitConverter.ToSingle(array, 0);
        }

        internal static bool TryLoadDataInt(string name, out int value, bool isCommon = true)
        {
            value = default;
            try
            {
                value = LoadDataInt(name, isCommon);
                return true;
            }
            catch (Exception ex) { Debug.LogException(ex); }
            return false;
        }

        internal static bool TryLoadDataBool(string name, out bool value, bool isCommon = true)
        {
            value = default;
            try
            {
                value = LoadDataBool(name, isCommon);
                return true;
            }
            catch (Exception ex) { Debug.LogException(ex); }
            return false;
        }

        internal static bool TryLoadDataString(string name, out string value, bool isCommon = true)
        {
            value = default;
            try
            {
                value = LoadDataString(name, isCommon);
                return true;
            }
            catch (Exception ex) { Debug.LogException(ex); }
            return false;
        }

        internal static bool TryLoadDataFloat(string name, out float value, bool isCommon = true)
        {
            value = default;
            try
            {
                value = LoadDataFloat(name, isCommon);
                return true;
            }
            catch (Exception ex) { Debug.LogException(ex); }
            return false;
        }

        internal static void SaveData(string name, int value, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Create);
            fileStream.Write(BitConverter.GetBytes(value), 0, 4);
            fileStream.Flush();
            fileStream.Close();
        }

        internal static void SaveData(string name, bool status, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Create);
            fileStream.Write(new byte[] { (byte)(status ? 1 : 0) }, 0, 1);
            fileStream.Flush();
            fileStream.Close();
        }

        internal static void SaveData(string name, string data, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Create);
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            fileStream.Write(buffer, 0, buffer.Length);
            fileStream.Flush();
            fileStream.Close();
        }

        internal static void SaveData(string name, float value, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Create);
            fileStream.Write(BitConverter.GetBytes(value), 0, 4);
            fileStream.Flush();
            fileStream.Close();
        }

        //Bổ sung 2 hàm này
        internal static void SaveData(string name, List<string> data, bool isCommon = true)
        {
            string path = dataPath;
            if (!isCommon)
                path = Path.Combine(Rms.GetiPhoneDocumentsPath(), "ModData");
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fileStream = new FileStream(Path.Combine(path, name), FileMode.Create);
            string jsonData = JsonUtility.ToJson(new Serialization<string>(data));
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            fileStream.Write(buffer, 0, buffer.Length);
            fileStream.Flush();
            fileStream.Close();
        }
        internal static bool TryLoadDataListString(string name, out List<string> value, bool isCommon = true)
        {
            value = default;
            try
            {
                string jsonData = LoadDataString(name, isCommon);
                value = JsonUtility.FromJson<Serialization<string>>(jsonData).ToList();
                return true;
            }
            catch (Exception ex) { Debug.LogException(ex); }
            return false;
        }
    }
}
