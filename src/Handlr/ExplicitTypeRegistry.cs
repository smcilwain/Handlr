// Copyright 2011 Steve McIlwain
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public Dictionary<Type, List<object>> TypeHandlers 
		{
			get { return _handlers ;}
		}
		
	
		//--------------------------------------------------------------------------------
		// Public Methods
		//--------------------------------------------------------------------------------
		
		
		/// <summary>
		/// RegisterHandler is used to store the associated type
		/// handler instance in the Handlers collection.
		/// </summary>
		/// <param name="handler"></param>
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

