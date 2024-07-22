
string bits = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

string Descriptografia(string bits)
{
    string[] ArrayBits = bits.Split(' ');
    int count = 0;

    foreach (string oitoBits in ArrayBits)
    {
        //Console.WriteLine(count);
        char[] invert = oitoBits.ToArray();
        char penul = invert[6];
        invert[6] = invert[7];
        invert[7] = penul;
        //Console.WriteLine("Array Antigo "  + ArrayBits[count]);
        Console.WriteLine(invert);
        count++;
    }
    return "oi";
}

Descriptografia(bits);
