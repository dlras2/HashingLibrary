﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Run00.MsTest;
using Crypto = System.Security.Cryptography;

namespace BitFn.HashingLibrary.Tests.Algorithms.CryptographyWrapper
{
	[TestClass]
	[CategorizeByConventionClass(typeof(ComputeHash))]
	public class ComputeHash
	{
		[TestMethod]
		[CategorizeByConvention]
		public void WhenCastAsIHashAlgorithm_ShouldMatchGenericResult()
		{
			// Arrange
			var fixture = new Fixture();
			var values = fixture.Create<byte[]>();
			// TODO: Mock Crypto.HashAlgorithm?
			var algorithm = new HashingLibrary.Algorithms.CryptographyWrapper(Crypto.MD5.Create());

			var expected = algorithm.ComputeHash(values);

			// Act
			var actual = ((IHashAlgorithm)algorithm).ComputeHash(values);

			// Assert
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}