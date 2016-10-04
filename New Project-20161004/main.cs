using System.IO;
using System;

class Program
{
    static void Main()
    {
        string leitor;
        Console.Write("Digite a quantidade de restrições e a quantidade de variáveis: ");
        
        leitor = Console.ReadLine();
        
        int qtdLin = Convert.ToInt16(leitor.Split(' ')[0])+1;
        int qtdCol = Convert.ToInt16(leitor.Split(' ')[1])+1;
        
        double[,] matriz = new double[qtdLin, qtdCol];
        
        for (int i=0;i<qtdLin;i++){
            
            Console.Write("Digite os valores da linha "+(i+1)+": ");
            leitor = Console.ReadLine();
            
            string[] nums = leitor.Split(' ');
            int c = 0;
            
            foreach (string n in nums) {
                if (n != "") matriz[i,c++] = Convert.ToDouble(n);
            }
            
        }
        
        while (true) {
            
            //Escolhendo a coluna pivô
            int cPivo = 0;
            for (int i=0;i<qtdCol-1;i++) {
                if (matriz[0,cPivo] < matriz[0,i]) {
                    cPivo = i;
                }
            }
            
            //Escolhendo a linha pivô
            int lPivo=1;
            double max = 0;
            for (int i=0;i<qtdLin;i++) {
                if (matriz[i,qtdLin-1] != 0) {
                    if (max < (matriz[i,cPivo]/matriz[i,qtdLin-1])) {
                        max = matriz[i,cPivo]/matriz[i,qtdLin-1];
                        lPivo = i;
                    }
                }
            }
            double elemPivo = matriz[lPivo, cPivo];
            
            
            //Divide a linha pivô pelo Elemento Pivô
            for (int i = 0;i<qtdCol;i++) {
                matriz[lPivo,i] = matriz[lPivo,i]/elemPivo;
            }
            
            //Aplica a Fórmula
            for (int i = 0;i<qtdLin;i++) {
                double elemCPivo = matriz[i,cPivo];
                if (i != lPivo) {
                    for (int j=0;j<qtdCol;j++) {
                        double elemLPivo = matriz[lPivo, j];
                        matriz[i,j]=matriz[i,j] - (elemCPivo*elemLPivo);
                    }
                }
            }
            
            //Se não houverem mais valores positivos na primeira linha, sai
            bool verifica = false;
            for (int i=0;i<qtdCol;i++) {
                if (matriz[0, i] >0) {
                    verifica = true;
                    break;
                } 
            }
            
            
            for (int i=0;i<qtdLin;i++) {
                for (int j=0;j<qtdCol;j++) {
                    Console.Write(matriz[i,j]+" ");
                }
                Console.WriteLine();
            }
            
            if (!verifica) break;
            
        }
        
    }
}
