using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.CompressedEmployee
{
    public static class ByteArrayCompressionUtility
    {
        public static byte[] Compress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressIntoMs = new MemoryStream())
            {
                using (var gzs = new BufferedStream(new GZipStream(compressIntoMs, CompressionMode.Compress)))
                {
                    gzs.Write(inputData, 0, inputData.Length);
                }
                return compressIntoMs.ToArray();
            }
        }

        public static byte[] Decompress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressedMs = new MemoryStream(inputData))
            {
                using (var decompressedMs = new MemoryStream())
                {
                    using (var gzs = new BufferedStream(new GZipStream(compressedMs, CompressionMode.Decompress)))
                    {
                        gzs.CopyTo(decompressedMs);
                    }
                    return decompressedMs.ToArray();
                }
            }
        }

        public static void SerializeAndCompress(this object obj, string fileWhereToSave)
        {
            using (FileStream ms = new FileStream(fileWhereToSave, FileMode.Truncate))
            using (GZipStream zs = new GZipStream(ms, CompressionMode.Compress, true))
            {
                Serializer.Serialize(zs, obj);
            }
        }

        public static T DecompressAndDeserialize<T>(this string fileToRead)
        {
            using (FileStream ms = new FileStream(fileToRead, FileMode.Open))
            using (GZipStream zs = new GZipStream(ms, CompressionMode.Decompress, true))
            {
                return Serializer.Deserialize<T>(zs);
            }
        }
    }
}
