namespace Trans2Quik.Core
{
    using System;
    using System.Text;
    using Entities.Order;
    using Internals;

    public class OrderInfoDetails
    {
        /// <summary>
        /// Количество заявки
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Дата заявки
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// Время заявки
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Временные параметры заявки
        /// </summary>
        public int OrderDateTime { get; set; }

        /// <summary>
        /// Время активации заявки
        /// </summary>
        public int ActivationTime { get; set; }

        /// <summary>
        /// Время снятия заявки
        /// </summary>
        public int WithdrawTime { get; set; }

        /// <summary>
        /// Дата окончания срока действия заявки
        /// </summary>
        public int Expiry { get; set; }

        /// <summary>
        /// Накопленный купонный доход
        /// </summary>
        public double AccuredInt { get; set; }

        /// <summary>
        /// Доходность
        /// </summary>
        public double Yield { get; set; }

        /// <summary>
        ///  UserID пользователя
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// Строковый идентификатор трейдера, от имени которого отправлена заявка
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Видимое количество для заявок типа «Айсберг»
        /// </summary>
        public int VisibleQty { get; set; }

        /// <summary>
        /// Период, когда была выставлена заявка
        /// </summary>
        public OrderInfoPeriod Period { get; set; }

        /// <summary>
        /// Дата и время выставления заявки в формате YY.MM.DD HH:MM:SS.MS
        /// </summary>
        public DateTime FileTime { get; set; }

        /// <summary>
        /// Дата и время снятия заявки в формате YY.MM.DD HH:MM:SS.MS
        /// </summary>
        public DateTime WithdawFileTime { get; set; }

        /// <summary>
        /// Торговый счет, указанный в заявке
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Комментарий заявки
        /// </summary>
        public string BrokerRef { get; set; }

        /// <summary>
        /// Код клиента, отправившего заявку
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Строковый идентификатор организации пользователя, отправившего заявку
        /// </summary>
        public string FirmId { get; set; }

        public bool InInterest
        {
            get
            {
                return !string.IsNullOrEmpty(this.FirmId) ||
                       !string.IsNullOrEmpty(this.ClientCode) ||
                       !string.IsNullOrEmpty(this.BrokerRef) ||
                       !string.IsNullOrEmpty(this.Account);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Qty={0} ", this.Qty);
            sb.AppendFormat("Date={0} ", this.Date);
            sb.AppendFormat("Time={0} ", this.Time);
            sb.AppendFormat("OrderDateTime={0} ", this.OrderDateTime);
            sb.AppendFormat("ActivationTime={0} ", this.ActivationTime);
            sb.AppendFormat("WithdrawTime={0} ", this.WithdrawTime);
            sb.AppendFormat("Expiry={0} ", this.Expiry);
            sb.AppendFormat("AccuredInt={0} ", this.AccuredInt);
            sb.AppendFormat("Yield={0} ", this.Yield);
            sb.AppendFormat("Uid={0} ", this.Uid);
            sb.AppendFormat("VisibleQty={0} ", this.VisibleQty);
            sb.AppendFormat("Period={0} ", this.Period);
            sb.AppendFormat("FileTime={0} ", this.FileTime);
            sb.AppendFormat("WithdawFileTime={0} ", this.WithdawFileTime);
            sb.AppendFormat("UserId={0} ", this.UserId);
            sb.AppendFormat("Account={0} ", this.Account);
            sb.AppendFormat("BrokerRef={0} ", this.BrokerRef);
            sb.AppendFormat("ClientCode={0} ", this.ClientCode);
            sb.AppendFormat("FirmId={0} ", this.FirmId);

            return sb.ToString().Trim();
        }

        internal static OrderInfoDetails Fetch(Int32 orderDescriptor, OrderInfoTimeType infoTimeType = OrderInfoTimeType.QuikDate)
        {
            var od = new OrderInfoDetails();

            if (orderDescriptor <= 0)
            {
                return od;
            }

            od.Qty = OrderEntryPoint.Qty(orderDescriptor);
            od.Date = OrderEntryPoint.Date(orderDescriptor);
            od.Time = OrderEntryPoint.Time(orderDescriptor);
            od.OrderDateTime = OrderEntryPoint.DateTime(orderDescriptor, (int)infoTimeType);
            od.ActivationTime = OrderEntryPoint.ActivationTime(orderDescriptor);
            od.WithdrawTime = OrderEntryPoint.WithdrawTime(orderDescriptor);
            od.Expiry = OrderEntryPoint.Expiry(orderDescriptor);
            od.AccuredInt = OrderEntryPoint.AccuredInt(orderDescriptor);
            od.Yield = OrderEntryPoint.Yield(orderDescriptor);
            od.Uid = OrderEntryPoint.Uid(orderDescriptor);
            od.VisibleQty = OrderEntryPoint.VisibleQty(orderDescriptor);
            od.Period = (OrderInfoPeriod)OrderEntryPoint.Period(orderDescriptor);
            od.FileTime = TypeConverter.GetDateTime(OrderEntryPoint.FileTime(orderDescriptor));
            od.WithdawFileTime = TypeConverter.GetDateTime(OrderEntryPoint.WithdawFileTime(orderDescriptor));
            od.UserId = OrderEntryPoint.UserId(orderDescriptor);
            od.Account = OrderEntryPoint.Account(orderDescriptor);
            od.BrokerRef = OrderEntryPoint.BrokerRef(orderDescriptor);
            od.ClientCode = OrderEntryPoint.ClientCode(orderDescriptor);
            od.FirmId = OrderEntryPoint.FirmId(orderDescriptor);

            return od;
        }
    }
}
