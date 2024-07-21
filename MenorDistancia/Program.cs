
int[] array1 = new int[] { -1, 5 };
int[] array2 = new int[] { 26, 6 };

int MenorDistancia(int[] array1, int[] array2)
{
    int MenorDistancia = int.MaxValue;
    for (global::System.Int32 i = 0; i <  array1.Length; i++)
    {
        int distancia = Math.Abs(array1[i] - array2[i]);
        if (distancia < MenorDistancia) { MenorDistancia = distancia; }
    }

    return MenorDistancia;
}



Console.WriteLine(MenorDistancia(array1, array2));
