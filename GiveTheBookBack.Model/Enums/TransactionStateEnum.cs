﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Enums
{
    public class TransactionStateEnum
    {
        public enum State
        {
            Waiting,
            Confirm,
            Refuse
        }
    }
}
