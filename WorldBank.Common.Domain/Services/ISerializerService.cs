using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Common.Domain.Services
{
    public interface ISerializerService
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string serializedObj);
    }
}
