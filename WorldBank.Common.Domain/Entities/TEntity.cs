﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Common.Domain.Entities
{
    public abstract class TEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
