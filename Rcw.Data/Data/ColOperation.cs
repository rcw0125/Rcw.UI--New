namespace Rcw.Data
{
    using System;

    [Flags]
    public enum ColOperation
    {
        All = 7,
        DeleteCondition = 8,
        Insert = 1,
        InsertReturnVal = 0x20,
        None = 0,
        Select = 4,
        Update = 2,
        UpdateCondition = 0x10
    }
}

