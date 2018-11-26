using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitcoinProject;
using Moq;

namespace UnitTestBitcoinProject
{
	[TestClass]
	public class BitcoinWalletTester
	{

		[TestMethod]
		public void TestGetCurrentValueInDollarsWithMockObject()
		{
			//set up
			BitcoinWallet tWallet = new BitcoinWallet();
			double bitcoinQty = 8;
			Mock<BitcoinPriceService> bitcoinPriceServiceMock = new Mock<BitcoinPriceService>();
			bitcoinPriceServiceMock.Setup(x => x.GetCurrentBitcoinPriceInDollars()).Returns(5000);

			//excercise
			Assert.AreEqual(40000, tWallet.GetCurrentValueInDollars(bitcoinQty,bitcoinPriceServiceMock.Object));
		}

		[TestMethod]
		public void TestVerifyValueBlank()
		{
			// Arrange
			string nbrBitcoin = " ";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyValue(nbrBitcoin);

			// Assert
			Assert.IsFalse(tWallet.VerifyValue(nbrBitcoin));
		}

		[TestMethod]
		public void TestVerifyValueNegative()
		{
			// Arrange
			string nbrBitcoin = "-10";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyValue(nbrBitcoin);

			// Assert
			Assert.IsFalse(tWallet.VerifyValue(nbrBitcoin));
		}

		[TestMethod]
		public void TestVerifyValuePositive()
		{
			// Arrange
			string nbrBitcoin = "10";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyValue(nbrBitcoin);

			// Assert
			Assert.IsTrue(tWallet.VerifyValue(nbrBitcoin));
		}

		[TestMethod]
		public void TestVerifyStringEmpty()
		{
			// Arrange
			string btcAddress = " ";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyString(btcAddress);

			// Assert
			Assert.IsFalse(tWallet.VerifyString(btcAddress));
		}

		[TestMethod]
		public void TestVerifyStringLengthShorter()
		{
			// Arrange
			string btcAddressShorter = "3TRY7DEQ5";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyString(btcAddressShorter);

			// Assert
			Assert.IsFalse(tWallet.VerifyString(btcAddressShorter));
		}

		[TestMethod]
		public void TestVerifyStringLengthLonger()
		{
			// Arrange
			string btcAddressLonger = "1BvBMSEYstWetqTFn5Au4m4GFg7xJaNVN237";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyString(btcAddressLonger);

			// Assert
			Assert.IsFalse(tWallet.VerifyString(btcAddressLonger));
		}

		[TestMethod]
		public void TestVerifyStringLengthValid()
		{
			// Arrange
			string btcAddressValid = "3J98t1WpEZ73CNmQviecrnyiWrnqRhWNLy";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyString(btcAddressValid);

			// Assert
			Assert.IsTrue(tWallet.VerifyString(btcAddressValid));
		}
		[TestMethod]
		public void TestVerifyStringStartsWith()
		{
			// Arrange
			string btcAddress = "bc18t1WpEZ73CNmQviecrnyiWrnqRhWNLy";
			BitcoinWallet tWallet = new BitcoinWallet();

			// Act
			tWallet.VerifyString(btcAddress);

			// Assert
			Assert.IsFalse(tWallet.VerifyValue(btcAddress));
		}
	}


}

