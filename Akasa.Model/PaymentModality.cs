using System;
using System.Collections.Generic;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class PaymentModality : FiniteDataEntity
    {
        //Cantidad de clases a las que un cliente puede ir en el periodo
        public int LessonQuantityAvailable { get; set; }
        //Cuanto tiempo tiene para tomar las clases
        public int LessonAvailabilityDays { get; set; }

        public decimal Cost { get; set; }

        public virtual List<UserPayment> LstUserPayment { get; set; } = new List<UserPayment>();
    }
}
