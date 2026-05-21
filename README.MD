# 💰 Conversor de Valores para Extenso em C#

Uma aplicação de console desenvolvida em C# (.NET) que converte valores numéricos (`decimal`) para a sua representação monetária por extenso em formato de Real Brasileiro (BRL). O sistema lida de forma inteligente com a separação matemática de reais e centavos, regras de plural/singular e múltiplos grupos numéricos (milhares, milhões, bilhões).

## 🚀 Funcionalidades

- **Precisão Matemática:** Separação robusta de reais e centavos utilizando métodos de truncamento e arredondamento, evitando os bugs clássicos de conversão baseada em strings.
- **Formatação Inteligente:** 
  - `R$ 600,00` ➡️ Seiscentos reais
  - `R$ 0,15` ➡️ Quinze centavos de real
  - `R$ 1.500,20` ➡️ Mil quinhentos reais e vinte centavos
  - `R$ 1,00` ➡️ Um real
- **Análise por Grupos:** Processamento de números grandes divididos em blocos de três dígitos (centenas, dezenas e unidades).
- **Tratamento Gramatical:** Regras aplicadas para inserção correta do conectivo "e" (ex: "cento e vinte") e tratamento especial para o número 100 ("cem" vs "cento").

## 🛠️ Como o Código Funciona

O fluxo principal do programa é dividido em três etapas essenciais:

1. **Separação de Componentes:**
   
```csharp
   long reais = (long)Math.Truncate(valorEntrada);
   int centavos = (int)Math.Round((valorEntrada - reais) * 100);
````
2. Dicionários de Mapeamento: Utilização de estruturas Dictionary<int, string> estáticas para traduzir números isolados de unidades, dezenas (incluindo a faixa crítica de 10 a 19) e centenas.

3. Máquina de Estados (If/Else): Um bloco condicional no método Main analisa o preenchimento das strings geradas para decidir a estrutura frasal exata da moeda corrente.


## 📖 Como Executar
1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone o repositório:
   ```bash
   git clone (https://github.com/Dayua-Santana/Cheque-por-Extenso)
3. Execute o código utilizando o comando:
    ```bash 
    dotnet run progam.cs