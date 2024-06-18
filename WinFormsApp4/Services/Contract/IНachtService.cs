using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4.Services.Contract
{
    internal interface IНachtService<T>
    {
        public void Set(T value);
        public void Update(T value);
    }
}
