
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Handlr
{
	/// <summary>
	/// ReflectedTypeRegistry can be used to dynamically build a 
	/// collection of type handlers at runtime using reflection.
	/// </summary>
	public sealed class ReflectedTypeRegistry 
	{
		//--------------------------------------------------------------------------------
		// Private Members
		//--------------------------------------------------------------------------------
		
		// The collection of types and corresponding handlers
		private readonly Dictionary<Type, List<object>> _handlers = new Dictionary<Type,List<object>>();
			
		//--------------------------------------------------------------------------------
		// Public Members
		//--------------------------------------------------------------------------------
				
		/// <summary>
		/// The dictionary collection of type handlers.
		/// </summary>
		public Dictionary<Type, List<object>> TypeHandlers 
		{
			get { return _handlers ;}
		}
		
		//--------------------------------------------------------------------------------
		// Constructors
		//--------------------------------------------------------------------------------
		
		/// <summary>
		/// Supply a list of one or more Assembly objects to
		/// scan for the IHandleTypes interface.  
		/// </summary>
		/// <param name="assemblies"></param>
		public ReflectedTypeRegistry(List<Assembly> assemblies)
		{
			if (assemblies == null) throw new ArgumentNullException("assemblies");
			
			foreach(var a in assemblies)
			{
				this.RegisterAssembly(a);
			}
			   
			if (_handlers.Count == 0) throw new ArgumentException("None of the assemblies scanned contain a type handler.");
					   
		}
		
		/// <summary>
		/// Supply an assembly to scan for the IHandleTypes interface.
		/// </summary>
		/// <param name="assembly"></param>
		public ReflectedTypeRegistry(Assembly assembly)
		{
			if (assembly == null) throw new ArgumentNullException("assemblies");
			
			this.RegisterAssembly(assembly);
					
			if (_handlers.Count == 0) throw new ArgumentException("The assembly scanned does not contain a type handler.");
		}
		
		/// <summary>
		/// Scans the calling assembly for the IHandleTypes interface.
		/// </summary>
		/// <param name="assembly"></param>
		public ReflectedTypeRegistry()
		{
			var a = Assembly.GetCallingAssembly();
			
			this.RegisterAssembly(a);
					
			if (_handlers.Count == 0) throw new ArgumentException("The calling assembly scanned does not contain a type handler.");
		}
				
		//--------------------------------------------------------------------------------
		// Private Methods
		//--------------------------------------------------------------------------------
		
		private void RegisterAssembly(Assembly a)
		{
				//Refelct over the assembly to find all the types
	                foreach (Type type in a.GetTypes())
	                {
	                    //if the type is an IHandleTypes
	                    Type typeHandlerClass = type.GetInterfaces().FirstOrDefault(
	                        i => i.IsGenericType &&
	                        i.GetGenericTypeDefinition().Name == typeof (IHandleTypes<>).Name);
	
	                    //Register an instance in the Handlers for that event type
	                    if (typeHandlerClass != null)
	                    {
	                    	//Get the type that is handled and use it as the key
	                    	var typeToHandle = typeHandlerClass.GetGenericArguments()[0];
	                    	
	                    	if (_handlers.ContainsKey(typeToHandle))
	                    	{
	                    		//add to current list of handler instances
	                    		var instances = _handlers[typeToHandle];
	                    		instances.Add(Activator.CreateInstance(type));
	              	                    		              
	                    	}
	                    	else
	                    	{
	                    		//add to a new list of handler instances
	                    		var instances = new List<object>();
	                    		instances.Add(Activator.CreateInstance(type));
	                    		
	                    		_handlers.Add(typeToHandle,instances);
	                    	}
	                    	
	              
	                    }
	                }
		}
			
	}
}
