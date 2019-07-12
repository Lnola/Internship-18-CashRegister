using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Interfaces
{
    public interface ICashierRegisterRepository
    {
        bool AddCashierRegister(int registerId, int cashierId);
    }
}
