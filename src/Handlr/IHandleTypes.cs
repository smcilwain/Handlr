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
using System.Reflection;
using System.Linq;

namespace Handlr
{
	/// <summary>
	/// The IHandleTypes generic interface should be implemented
	/// by classes that will process the generic type, aka "Handlers"
	/// </summary>
	public interface IHandleTypes<T>
	{
		
		/// <summary>
		/// Implement the Handle method which should be called
		/// by the type router
		/// </summary>
		/// <param name="handledType"></param>
		void Handle(T handledType);
		
	}

}
