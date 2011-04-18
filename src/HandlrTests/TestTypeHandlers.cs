
using System;
using System.Collections.Generic;
using System.Reflection;
using Handlr;
using NUnit.Framework;

namespace HandlrTests
{
	public class TestTypeHandlerA : IHandleTypes<TestTypeToHandle1>
	{

		public void Handle(TestTypeToHandle1 t)
		{
			Assert.NotNull(t);
		}
		
	}
	
	public class TestTypeHandlerB : IHandleTypes<TestTypeToHandle1>
	{

		public void Handle(TestTypeToHandle1 t)
		{
			Assert.NotNull(t);
		}
		
	}
	
	public class TestTypeHandlerC : IHandleTypes<TestTypeToHandle2>
	{
		
		
		public void Handle(TestTypeToHandle2 t)
		{
			Assert.NotNull(t);
		}
		
	}
}
