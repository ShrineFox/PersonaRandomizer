using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlusTableLib.Serialization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class TableAttribute : Attribute
    {
        public Game[] Games { get; }

        public string Name { get; set; }

        public TableAttribute(params Game[] games)
        {
            Games = games.Length != 0? games : throw new ArgumentException("Value cannot be an empty collection.", nameof(games)); 
        }
    }
}
