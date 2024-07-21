using System.Globalization;

string input = "12\r\n1,0,15.4,50\r\n2,0,15.5,50\r\n2,2,0,0\r\n2,0,15.4,10\r\n3,0,15.9,30\r\n3,1,0,20\r\n4,0,16.50,200\r\n5,0,17.00,100\r\n5,0,16.59,20\r\n6,2,0,0\r\n1,2,0,0\r\n2,1,15.6,0";

Dictionary<int, (double Valor, int Quantidadde)> livrosOfertas = new Dictionary<int, (double Valor, int Quantidadde)>();

void LivroOfertas(string logs)
{
    string[] lines = logs.Split('\n');

    int linhas = 0;


    foreach (string line in lines)
    {
        string[] elementos = line.Split(',');

        if(elementos.Length <= 1)
        {
            linhas = int.Parse(line);
        } else
        {
            switch (int.Parse(elementos[1]))
            {
                case 0:
                    Inserir(elementos);
                    break;
                case 1:
                    Modificar(elementos);
                    break;
                case 2:
                    Deletar(elementos);
                    break;
            }
        }
    }
    foreach (var item in ReindexarDicionario(livrosOfertas))
    {
        int posicao = item.Key;
        double valor = item.Value.Valor;
        int quantidade = item.Value.Quantidade;
        Console.WriteLine($"{posicao},{valor.ToString(CultureInfo.InvariantCulture)},{quantidade}");
    };
}

void Inserir(string[] linha)
{
    
    var key = int.Parse(linha[0]);
    if (livrosOfertas.ContainsKey(key))
    {
        key++;
        livrosOfertas.Add(key, (Double.Parse(linha[2], CultureInfo.InvariantCulture), int.Parse(linha[3])));
    }
    else
    {
        livrosOfertas.Add(int.Parse(linha[0]), (Double.Parse(linha[2], CultureInfo.InvariantCulture), int.Parse(linha[3])));
    }
}

void Modificar(string[] linha)
{
    livrosOfertas[int.Parse(linha[0])] = (Double.Parse(linha[2], CultureInfo.InvariantCulture), int.Parse(linha[3]));
}

void Deletar(string[] linha)
{
    livrosOfertas.Remove(int.Parse(linha[0]));
}

Dictionary<int, (double Valor, int Quantidade)> ReindexarDicionario(Dictionary<int, (double Valor, int Quantidade)> dicionarioOriginal)
{
    var dicionarioReindexado = new Dictionary<int, (double Valor, int Quantidade)>();

    int novaChave = 1;
    foreach (var item in dicionarioOriginal.OrderBy(kvp => kvp.Key))
    {
        dicionarioReindexado[novaChave] = item.Value;
        novaChave++;
    }

    return dicionarioReindexado;
}

LivroOfertas(input);