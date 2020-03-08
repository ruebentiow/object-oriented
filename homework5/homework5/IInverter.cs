// Name: Rueben Tiow
// Last Modification: 3/9/2017
// File: IInverter.cs
// Version: 1.0
// Purpose: This is an Inverter interface that lays the foundation for 
// other classes to implement the methods. The purpose of this interface
// is to contain the function signatures of Inverter intended to be 
// implemented by a class that implements the members of the interface 
// specified in this interface definition.
// Interface Invariants:
// - All methods are only allowed to be passed by value.
// - Every string passed into this object must be in english lowercase 
//   alphabet letters.
// - All words must be at least 4 characters long.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    interface IInverter 
    {
        bool GetState();
        string GetInvertVariant(string AnyWord);
    }
}
