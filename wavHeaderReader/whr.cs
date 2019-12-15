using System;
using System.IO;

namespace wavHeadReader
{
    // channels = 22; bitDepth = 34; freq = 24-27; bps = 28-31; dataSize = 36-39
    //
    public class Wave
    {
        public byte channels;
        public byte bitDepth;
        public int freq;
        public int bitsPerSample;
        public int dataSize;
        public int chunkSize;
        private byte[] header = new byte[44];
        public void recieveFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                fs.Read(header, 0, header.Length);
                fs.Close();
            }
            workWithFile();
        }
        public void recieveFile(byte[] binary)
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
