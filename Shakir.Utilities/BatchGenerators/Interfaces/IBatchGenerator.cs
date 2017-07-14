using System.Collections.Generic;

namespace Shakir.Utilities.BatchGenerators.Interfaces
{
    public interface IBatchGenerator
    {
        List<List<T>> GetItemsInBatches<T>(List<T> items, int idsPerBatch);
    }
}
