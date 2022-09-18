using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Tinnova_Artur.Models
{
	public class BubbleSort
	{
		private int[] bubbleSort = { 5, 3, 2, 4, 7, 1, 0, 6 };

		public int[] result { get; set; }

		public BubbleSort()
		{
			this.result = GerarOrdem(bubbleSort);
		}


		public static int[] GerarOrdem(int[] param)
		{
			int tamanho = param.Length, verifica = 0, trocarPos = 0;


			for (int i = tamanho - 1; i >= 1; i--)
			{
				for (int j = 0; j < i; j++)
				{
					verifica++;
					if (param[j] > param[j + 1])
					{
						int aux = param[j];
						param[j] = param[j + 1];
						param[j + 1] = aux;
						trocarPos++;
					}
				}
			}
			return param;
		}

	}
}
