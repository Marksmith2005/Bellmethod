using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellStuff
{
    public class Method
    {
        /// <summary>
        /// hold the data for eatch bellrining method made by the user 
        /// MethodLenght is how many bells there are eg 12
        /// 
        /// MethodPN is the placenotation what is a place notation? https://ringingteachers.org/handbells/place-notation
        /// TtoalMethod is the entire method set out in its rows eg
        /// 123456
        /// 214365
        /// 123456
        /// TrebbelOrintated dictates wether the methods trebbel follows a set path eg in grandsire or plain bob - true means it is flase means its not
        /// MethodType describes what methd it is eg kent is trebbel bob
        /// MethodName is what the user calls it 
        ///MethodFalse if this is true at anypoint the method is allways false and can not be a method
        /// </summary>
        public int MethodLenght { get; set; }
        public string[] MethodPN { get; set; }
        public int[] TtoalMethod { get; set; }
        public bool TrebbelOrintated { get; set; }
        public string MethodType { get; set; }
        public string MethodName { get; set; }
        public bool MethodFalse { get; set; }
        public int MethodLeadCount { get; set; }
        public int MethodRowCount { get; set; }

    }
}
