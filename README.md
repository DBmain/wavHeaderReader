Using:

wavHeaderReader.Wave test = new wavHeaderReader();
test.sendData("C:\\test.wav");

// OR

byte[] wavBytes;
... // filling wavBytes with data from file
test.sendData(wavBytes);
Console.WriteLine(test.freq, test.dataSize); // etc.
