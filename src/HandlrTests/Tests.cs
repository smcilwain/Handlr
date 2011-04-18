
using System;
using System.Collections.Generic;
using System.Reflection;
using Handlr;
using NUnit.Framework;

namespace HandlrTests
{

	[TestFixture]
	public class Tests
	{
		
		[Test]
		public void CreateHandlersWithDefaultCtor()
		{
			
			var r = new ReflectedTypeRegistry();
			
			Assert.NotNull(r);
			Assert.Greater(r.TypeHandlers.Count,0);
			Assert.AreEqual(r.TypeHandlers.Count,2);
						
			foreach (var h in r.TypeHandlers)
			{
				Assert.NotNull(h.Key);
				Assert.NotNull(h.Value);
						
				
			}

		}
		
		[Test]
		public void CreateHandlersWithSingleAssemblyCtor()
		{
			
			var r = new ReflectedTypeRegistry(Assembly.GetExecutingAssembly());
			
			Assert.NotNull(r);
			Assert.Greater(r.TypeHandlers.Count,0);
			Assert.AreEqual(r.TypeHandlers.Count,2);
						
			foreach (var h in r.TypeHandlers)
			{
				Assert.NotNull(h.Key);
				Assert.NotNull(h.Value);
						
			}

		}

		[Test]
		public void CreateHandlersWithMultiAssemblyCtor()
		{
			var assemblies = new List<Assembly>();
			assemblies.Add(Assembly.GetExecutingAssembly());
			
			var r = new ReflectedTypeRegistry(assemblies);
			
			Assert.NotNull(r);
			Assert.Greater(r.TypeHandlers.Count,0);
			Assert.AreEqual(r.TypeHandlers.Count,2);
						
			foreach (var h in r.TypeHandlers)
			{
				Assert.NotNull(h.Key);
				Assert.NotNull(h.Value);
						
			}

		}
		
		[Test][ExpectedException(typeof(ArgumentNullException))]
		public void CreateHandlersWithNullArgument()
		{
			Assembly a = null;
			var r = new ReflectedTypeRegistry(a);
		}
		
		[Test][ExpectedException(typeof(ArgumentException))]
		public void CreateHandlersWithBadArgument()
		{
			Assembly a = Assembly.GetAssembly(new object().GetType());
			var r = new ReflectedTypeRegistry(a);
		}

		[Test]
		public void CreateHandlersExplicitly()
		{
			
			var r = new ExplicitTypeRegistry();
			
			Assert.NotNull(r);
			
			r.RegisterHandler<TestTypeToHandle1>(new TestTypeHandlerA());
			r.RegisterHandler<TestTypeToHandle1>(new TestTypeHandlerB());
			r.RegisterHandler<TestTypeToHandle2>(new TestTypeHandlerC());
					
			Assert.Greater(r.TypeHandlers.Count,0);
			Assert.AreEqual(r.TypeHandlers.Count,2);
						
			foreach (var h in r.TypeHandlers)
			{
				Assert.NotNull(h.Key);
				Assert.NotNull(h.Value);
						
				
			}

		}
		
		
	}
	
	

	

	
	
	
}