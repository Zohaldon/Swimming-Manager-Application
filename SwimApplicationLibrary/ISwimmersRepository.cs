using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public interface ISwimmersRepository
    {
        int Number
        {
            set;
            get;
        }
        void Add(Registrant newSwimmer);
        void Load(string fileName, string delimeter);
        void Save(string fileName, string delimeter);
        Registrant GetByRegNum(int regNo);
    }
}
