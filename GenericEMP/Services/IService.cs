using System;
using GenericEMP.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericEMP.Services
{
	public interface IService<TModel, in TKey> 
	{
		// Read all records from Collections

		void Get();
		// Read a single record based on Key
		TModel Get(TKey id);
		// CReate a new Record
		IEnumerable<TModel> Create(TModel model);
		// Update record based on key
		void Update(TKey id, TModel model);
		// Delete record based on key
		bool Delete(TKey id);
	}
}
