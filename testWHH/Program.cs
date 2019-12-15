using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using wavHeaderReader;

namespace testWHH
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadHead test = new wavHeaderReader.ReadHead();
            byte[] a = File.ReadAllBytes("C:\\Users\\DB\\Desktop\\09 Sober_0.wav");
            test.recieveFile("C:\\Users\\DB\\Desktop\\09 Sober_0.wav");
            Console.WriteLine(test.bps + " " + test.channels + " " + test.dataSize + " " + test.bitDepth + " " + test.freq);
            Console.ReadKey();
        }
    }
}
