
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Handlr
{
		
	public interface IHandleTypes<T>
	{
		
		void Handle(T handledType);
		
	}

}