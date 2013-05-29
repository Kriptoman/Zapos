﻿using System.Collections.Generic;
using System.IO;
using Zapos.Common.DocumentModel;

namespace Zapos.Common.Printers
{
    public interface ITablePrinter
    {
        Stream Print(Table table);

        void Init(IDictionary<string, object> config);
    }
}
