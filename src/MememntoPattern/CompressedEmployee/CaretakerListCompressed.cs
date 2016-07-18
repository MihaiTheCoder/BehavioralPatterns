using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.CompressedEmployee
{
    /// <summary>
    /// Caretaker
    /// </summary>
    public class CaretakerListCompressed : ICaretaker<Employee>
    {
        private static string fileWhereToSave = Path.GetTempFileName();
        

        public void Revert(Employee obj)
        {
            List<byte[]> historyDeserialized = ReadFile();

            if (!historyDeserialized.Any())
                return;

            var lastItem = historyDeserialized.Pop();

            historyDeserialized.SerializeAndCompress(fileWhereToSave);

            obj.Revert(lastItem);
        }        

        public void Save(Employee obj)
        {
            List<byte[]> mementosHistory = ReadFile();
            mementosHistory.Add(obj.Save());

            mementosHistory.SerializeAndCompress(fileWhereToSave);
        }

        private static List<byte[]> ReadFile()
        {
            List<byte[]> historyDeserialized;

            if (new FileInfo(fileWhereToSave).Length != 0)
                historyDeserialized = fileWhereToSave.DecompressAndDeserialize<List<byte[]>>();
            else
                historyDeserialized = new List<byte[]>();

            return historyDeserialized;
        }

        public void PrintSizeOfFile()
        {
            Console.WriteLine("Size of compressed file: " + SizeSuffix(new FileInfo(fileWhereToSave).Length));
        }

        public void PrintSizeOfDecompressedHistory()
        {
            long historySize = 0;
            var historyDeserialized = fileWhereToSave.DecompressAndDeserialize<List<byte[]>>();
            historySize = historyDeserialized.Sum(h => h.Length);

            Console.WriteLine("Size of all the objects saved in caretaker: " + SizeSuffix(historySize));
        }

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }

    static class ListExtension
    {
        public static T Pop<T>(this List<T> list)
        {
            int index = list.Count - 1;
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }
    }


}
