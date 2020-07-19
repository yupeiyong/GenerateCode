using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Temps
{
    class Class1
    {
                /// <summary>
        ///     总提成
        /// </summary>
        public double TotalCommission { get; set; }

        public long OrderId { get; set; }

        /// <summary>
        /// 会计员修改时间
        /// </summary>
        public DateTime? AccountantUpdateDateTime { get; set; }
    }
}
