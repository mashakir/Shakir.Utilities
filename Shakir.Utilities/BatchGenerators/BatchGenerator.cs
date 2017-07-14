using System;
using System.Collections.Generic;
using System.Linq;
using Shakir.Utilities.BatchGenerators.Interfaces;
using Shakir.Utilities.Extensions;

namespace Shakir.Utilities.BatchGenerators
{
    public class BatchGenerator : IBatchGenerator
    { 
        public List<List<T>> GetItemsInBatches<T>(List<T> items, int idsPerBatch)
        {
            var batchLists = new List<List<T>>();
            if (!items.ToSafeArray().Any())
                return batchLists;

            var batchCounts = Math.Ceiling((decimal)items.Count / idsPerBatch);
            var seed = 0;
            for (var index = 0; index < batchCounts; index++)
            {
                batchLists.Add(items.Skip(seed).Take(idsPerBatch).ToList());
                seed = seed + idsPerBatch;
            }

            return batchLists;
        }
    }
}
