using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whrtest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] a = File.ReadAllBytes("D:\\Downloads\\other\\SebastiAn - Thirst (2019) [Hi-Res stereo].zip");
            Console.WriteLine("a");
            wavHeaderReader.Wave test = new wavHeaderReader.Wave();
            test.sendData(a);
            Console.WriteLine(test.freq + " " + test.dataSize + " " + test.chunkSize + " " + test.channels + " " + test.bitDepth + " " + test.bitsPerSample);
            Console.ReadKey();
        }
    }
}
