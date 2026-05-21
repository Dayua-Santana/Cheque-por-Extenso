using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

class Program
{

    static Dictionary<int, string> unidades = new Dictionary<int, string>()
        {
            { 0, "zero" }, { 1, "um" }, { 2, "dois" }, { 3, "três" }, { 4, "quatro" },
            { 5, "cinco" }, { 6, "seis" }, { 7, "sete" }, { 8, "oito" }, { 9, "nove" }
        };

     static Dictionary<int, string> dezenas10a19 = new Dictionary<int, string>
        {
            { 10, "dez" }, { 11, "onze" }, { 12, "doze" }, { 13, "treze" }, { 14, "quatorze" },
            { 15, "quinze" }, { 16, "dezesseis" }, { 17, "dezessete" }, { 18, "dezoito" }, { 19, "dezenove" }
        };

     static Dictionary<int, string> dezenas = new Dictionary<int, string> {
            { 2, "vinte" }, { 3, "trinta" }, { 4, "quarenta" }, { 5, "cinquenta" },
            { 6, "sessenta" }, { 7, "setenta" }, { 8, "oitenta" }, { 9, "noventa" }
        };

     static Dictionary<int, string> centenas = new Dictionary<int, string> {
             { 1, "cento" }, { 2, "duzentos" }, { 3, "trezentos" }, { 4, "quatrocentos" },
             { 5, "quinhentos" }, { 6, "seiscentos" }, { 7, "setecentos" }, { 8, "oitocentos" }, { 9, "novecentos" }
        };

    static string ConverterTresDigitos(int numero)
    {
        if(numero == 0) return "";
        if(numero == 100) return "cem";

        List<string> partes = new List<string>();

        int c = numero / 100;
        int d = (numero % 100) / 10;
        int u = numero % 10;

        if(c > 0) partes.Add(centenas[c]);


        if(d == 1)
        {
            partes.Add(dezenas10a19[d * 10 + u]);
        }
        else
        {
            if (d > 1) partes.Add(dezenas[d]);
            if (u > 0) partes.Add(unidades[u]);
        }

        return string.Join(" e ", partes);

    }
    static void Main()
    {
      decimal valorEntrada = 1000.0m;

      // Separando Reais e Centavos de forma matemática (mais seguro que String)
      long reais = (long)Math.Truncate(valorEntrada);
      int centavos = (int)Math.Round((valorEntrada - reais) * 100);

      string resultadosReais = ConverterReais(reais);
      string resultadosCentavos = ConverterCentavos(centavos);

      string resultadoFinal = "";
      if(!string.IsNullOrEmpty(resultadosReais) && !string.IsNullOrEmpty(resultadosCentavos))
        {

            resultadoFinal = $"{resultadosReais} e {resultadosCentavos}";            
        }
        else if(!string.IsNullOrEmpty(resultadosCentavos))
        {
            resultadoFinal = $"{resultadosCentavos} de real";
        }
        else if(!string.IsNullOrEmpty(resultadosReais))
        {
            resultadoFinal = resultadosReais;
        }
        else
        {
            resultadoFinal = "Zero reais";
        }

         if (!string.IsNullOrEmpty(resultadoFinal))
         {
            resultadoFinal = char.ToUpper(resultadoFinal[0]) + resultadoFinal.Substring(1);
         }

        Console.Clear();
        Console.WriteLine($"Valor: {valorEntrada:C2}");
        Console.WriteLine($"Por extenso: {resultadoFinal}");
    
    }

    static string ConverterReais(long valor)
    {
        if (valor == 0) return "";
        if (valor == 1) return "um real";

        string[] sufixosSingular = {"", "mil", "milhão", "bilhão"};
        string[] sufixosPlural = {"", "mil", "milhões", "bilhões"};

        List<string> partesExtenso = new List<string>();
        int grupoPosicao = 0;
        long valorOriginal = valor;

        while (valor > 0)
        {
            int grupo = (int)(valor % 1000);
            if(grupo > 0)
            {
                string textoGrupo = ConverterTresDigitos(grupo);
                string sufixo = "";

                if(grupoPosicao > 0)
                {
                    sufixo = grupo > 1 ? sufixosPlural[grupoPosicao] : sufixosSingular[grupoPosicao];
                }

                if(grupo == 1 && grupoPosicao == 1) textoGrupo = "";

                string textoCompleto = string.IsNullOrEmpty(sufixo) ? textoGrupo : $"{textoGrupo} {sufixo}".Trim();
                partesExtenso.Insert(0, textoCompleto);
            }
            valor /= 1000;
            grupoPosicao++;
        }
    int restoCentena = (int)(valorOriginal % 1000);
    if(partesExtenso.Count > 1 && (restoCentena < 100 || restoCentena % 100 == 0))
        {
            return string.Join(" e ", partesExtenso) + " reais";
        }

    return string.Join(" ",partesExtenso) + " reais";
    }
    static string ConverterCentavos(int centavos)
    {
        if(centavos == 0) return "";
        if(centavos == 1) return "um centavo de real";

        return $"{ConverterTresDigitos(centavos)} centavos";

    }
}