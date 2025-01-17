﻿using System.Collections.Generic;

namespace AsmForThreadsStream
{
    class IncrementOperation : IOperation
    {
        private readonly string _address;

        public IncrementOperation(string address)
        {
            _address = address;
        }

        public IEnumerable<IAtomic> GetOperations()
        {
            yield return new ReadOperation(_address, 0);
            yield return new PutConstantToRigister(1, 1);
            yield return new AddOperation();
            yield return new WriteOperation(_address);
        }
    }
}
