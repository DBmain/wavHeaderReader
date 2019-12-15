using System;
using System.IO;

namespace wavHeadReader
{
    public class Wave
    {
        public byte channels;
        public byte bitDepth;
        public int freq;
        public int bitsPerSample;
        public int dataSize;
        public int chunkSize;
        private byte[] header = new byte[44];
        public void sendData(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                fs.Read(header, 0, header.Length);
                fs.Close();
            }
            workWithFile();
        }
        public void sendData(byte[] binary)
        {
            for (int i = 0; i < 44; i++)
            {
                header[i] = binary[i];
            }
            workWithFile();
        }
        private void workWithFile()
        {
            channels = header[22];
            bitDepth = header[34];
            freq = BitConverter.ToInt32(header, 24);
            bitsPerSample = BitConverter.ToInt32(header, 28);
            dataSize = BitConverter.ToInt32(header, 36);
            chunkSize = BitConverter.ToInt32(header, 4);

        }
    }

}
