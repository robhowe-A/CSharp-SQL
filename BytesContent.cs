/*
 * Description: This program is created to test byte array sending using ByteArrayContent
 * class, derived from Http content.
 * 
 * MemoryStream Class documentation source:
 * https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-9.0
 * 
 * Date: 1-22-2025
 * Author: Robert Howell
 */
namespace BytesApp;

class ByteContent
{
    static void Main()
    {
        // Create byte array
        byte[] IP = [192, 168, 10, 101];

        // Assign byte array for http content test
        ByteArrayContent byteArrayContent = new(IP);
        
        // Read byte array to memory stream
        Stream result = byteArrayContent.ReadAsStream();
        
        // Read full memory stream
        byte[] buffer = new byte[result.Length]; // Buffer created for result

        // Read the remaining bytes, byte by byte.
        int count = result.Read(buffer);
        while (count < result.Length)
        {
            buffer[count++] = (byte)result.ReadByte();
        }

        // Loop to print the result
        for (var i=0; i < buffer.Length; i++)
        {
            if(i == buffer.Length - 1)
                Console.Write(buffer[i]);
            else
                Console.Write($"{buffer[i]}.");
        }
    }
};