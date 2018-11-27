using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinProject
{
	public class BitcoinWallet
	{
		public string GetAddres()
		{
			Console.WriteLine("** My Wallet Service **");
			Console.Write("\nEnter Bitcoin Address: ");
			string bitcoinAddress = Console.ReadLine();
			while (VerifyString(bitcoinAddress) == false)
			{
				Console.Write("The Bitcoin Address entered is not valid.  \nPlease enter a valid address: ");
				bitcoinAddress = Console.ReadLine();
			}
			return bitcoinAddress;
		}

		public double GetNumberOfBitcoins()
		{
			
			Console.Write("Enter Bitcoin Quantity: ");
			string strBitcoinQty = Console.ReadLine();
	
			while (VerifyValue(strBitcoinQty) == false)
			{
				Console.Write("The Bitcoin Quantity entered is not valid.  \nPlease enter a new value: ");
				strBitcoinQty = Console.ReadLine();
			}
			double bitcoinQuantity = Convert.ToDouble(strBitcoinQty);
			//return bitcoinQuantity;
		}

		public double GetCurrentValueInDollars(double bitcoinQuantity, BitcoinPriceService priceService)
		{
			//BitcoinPriceService bitcoinPriceService = new BitcoinPriceService();
			//double bitcoinValueInDollars = bitcoinQuantity * bitcoinPriceService.GetCurrentBitcoinPriceInDollars();
			double bitcoinValueInDollars = bitcoinQuantity * priceService.GetCurrentBitcoinPriceInDollars();
			Console.Write("\nThe current value in dollars is: " + bitcoinValueInDollars);
			
			return bitcoinValueInDollars;
		}

		public Boolean VerifyValue(string nbrValue)
		{
			Boolean validValue = false;
			Double value;

			if (Double.TryParse(nbrValue, out value) == false)
			{
				validValue = false;
			}
			else
			{ 
				if (value >= 0)
				{
					validValue = true;
				}
				else
				{
					validValue = false;
				}
			}
			return validValue;
		}

		public Boolean VerifyString(string strValue)
		{
			Boolean validString = false;

			if (string.IsNullOrEmpty(strValue))
			{
				validString = false;
			}
			else
			{
				if (strValue.Length > 35 || strValue.Length < 26)
				{
					validString = false;
				}
				else
				{
					if (strValue.StartsWith("1") || strValue.StartsWith("3"))
					{
						validString = true;
					}
					else
					{
						validString = false;
					}
				}
			}
			return validString;
		}
	}
}
