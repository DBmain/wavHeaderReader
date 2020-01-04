using System;
using System.IO;

namespace whrtest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] a = File.ReadAllBytes("D:\\Downloads\\other\\spin-go\\MYD - Superdiscoteca (Extended)1.wav");
            Console.WriteLine("a");
            wavHeaderReader.Wave test = new wavHeaderReader.Wave();
            test.sendData(a);
            Console.WriteLine(test.freq + " " + test.dataSize + " " + test.chunkSize + " " + test.channels + " " + test.bitDepth + " " + test.bitsPerSample + " " + test.dataStart + " " + test.dataEnd);
            Console.ReadKey();
        }
    }
}
