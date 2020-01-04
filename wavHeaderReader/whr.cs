using System;
using System.IO;

namespace wavHeaderReader
{
    public class Wave
    {
        public byte channels;
        public byte bitDepth;
        public int freq;
        public int bitsPerSample;
        public int dataSize;
        public int chunkSize;
        public int dataStart;
        public int dataEnd;
        private byte[] header = new byte[44];
        public void sendData(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                fs.Read(header, 0, header.Length);
                fs.Close();
            }
            workWithFile(path, null);
        }
        public void sendData(byte[] binary)
        {
            for (int i = 0; i < 44; i++)
            {
                header[i] = binary[i];
            }
            workWithFile(null, binary);
        }
        private void workWithFile(string path, byte[] bin)
        {
            channels = header[22];
            bitDepth = header[34];
            freq = BitConverter.ToInt32(header, 24);
            bitsPerSample = BitConverter.ToInt32(header, 28);
            byte[] fullFile;
            dataStart = 44;
            if (BitConverter.ToInt32(header, 36) != 1635017060)
            {
                if (path == null) fullFile = bin;
                else fullFile = File.ReadAllBytes(path);
                for (int i = 36; i < fullFile.Length; i++)
                {
                    if (fullFile[i] == 0 && BitConverter.ToInt32(fullFile, i + 1) == 1635017060)
                    {
                        dataStart = i + 1;
                        break;
                    }
                }
                dataSize = BitConverter.ToInt32(fullFile, dataStart + 4);
                dataStart = dataStart + 8;
            }
            else dataSize = BitConverter.ToInt32(header, 40);
            chunkSize = BitConverter.ToInt32(header, 4);
            dataEnd = dataStart + dataSize;
        }
    }

}
