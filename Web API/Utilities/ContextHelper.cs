using Microsoft.EntityFrameworkCore;
using System;

namespace Web_API
{
    public class ContextHelper<T> where T : DbContext, new()
    {
        /// <summary>
        /// Once we have multiple contexts across multiple environments, this bad boy really comes in handy. 
        /// Realistically it wouldnt live inside of the api project unless our application only consisted of a single api.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public T BuildContext(string connectionString)
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseSqlServer(connectionString, o => o.CommandTimeout(36000))
                .Options;

            return (T)Activator.CreateInstance(typeof(T), options);
        }
    }
}
