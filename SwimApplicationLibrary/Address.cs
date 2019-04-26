using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApplicationLibrary
{
    public struct Address
    {
        /*fileds*/
        public string street;
        public string city;
        public string province;
        public string postalCode;



        /*Constructor*/
        public Address(string street, string city, string province, string postalCode)
        {
            this.street = street;
            this.city = city;
            this.province = province;
            this.postalCode = postalCode;
        }
        
        /*ToString*/
        public override string ToString()
        {
            return string.Format($"\n\t {street} \n\t {city} \n\t {province} \n\t {postalCode}");
        }
        
    }
}
