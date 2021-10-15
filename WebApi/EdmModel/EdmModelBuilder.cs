using DomainModel;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.EdmModel
{
	public static class EdmModelBuilder
	{
		public static IEdmModel GetEdmModel()
		{
			var builder = new ODataConventionModelBuilder();

			builder.EntitySet<Classroom>("Classroom");
			//builder.EntitySet<Person>("People");

			return builder.GetEdmModel();
		}
	}

}
