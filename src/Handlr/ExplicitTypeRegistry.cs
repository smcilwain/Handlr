
using System;
using System.Collections.Generic;

namespace Handlr
{
	/// <summary>
	/// ExplicitTypeRegistry can be used to manually build a 
	/// collection of type handlers at design time.
	/// </summary>
	public sealed class ExplicitTypeRegistry
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
		
		public ExplicitTypeRegistry()
		{
		}
		
		//--------------------------------------------------------------------------------
		// Public Methods
		//--------------------------------------------------------------------------------
		
		public void RegisterHandler<T>(IHandleTypes<T> handler)
		{
			           
			var typeToHandle = typeof(T);
			
        	if (_handlers.ContainsKey(typeToHandle))
        	{
        		//add to current list of handler instances
        		var instances = _handlers[typeToHandle];
        		instances.Add(handler);
  	                    		              
        	}
        	else
        	{
        		//add to a new list of handler instances
        		var instances = new List<object>();
        		instances.Add(handler);
        		
        		_handlers.Add(typeToHandle,instances);
        	}
			
		}
		
		
		
	}
}

