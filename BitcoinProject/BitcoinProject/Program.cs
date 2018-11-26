using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinProject
{
	class Program
	{
		static void Main(string[] args)
		{
			BitcoinWallet wallet = new BitcoinWallet();
			BitcoinPriceService priceService = new BitcoinPriceService();

			string walletAddress = wallet.GetAddres();
			double walletNumberOfBitcoins = wallet.GetNumberOfBitcoins();
			//double walletValueInDollars = wallet.GetCurrentValueInDollars(walletNumberOfBitcoins);
			double walletValueInDollars = wallet.GetCurrentValueInDollars(walletNumberOfBitcoins, priceService);

			Console.ReadKey();
		}
	}
}
