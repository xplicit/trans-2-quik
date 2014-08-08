namespace Trans2Quik.Core.Entities.Trade
{
    using System;
    using System.Text;
    using Internals;

    public class TradeDetails
    {
        /// <summary>
        /// Торговый счет сделки
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string BrokerRef { get; set; }

        /// <summary>
        /// Код клиента сделки
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Валюта, в которой торгуется инструмент сделки
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Код биржи
        /// </summary>
        public string ExchangeCode { get; set; }

        /// <summary>
        /// Идентификатор организации пользователя сделки
        /// </summary>
        public string FirmId { get; set; }

        /// <summary>
        /// Идентификатор организации-партнера по сделке
        /// </summary>
        public string PartnerFirmId { get; set; }

        /// <summary>
        /// Код расчетов по сделке
        /// </summary>
        public string SettleCode { get; set; }

        /// <summary>
        /// Валюта расчетов по сделке
        /// </summary>
        public string SettleCurrency { get; set; }

        /// <summary>
        /// Идентификатор рабочей станции
        /// </summary>
        public string StationId { get; set; }

        /// <summary>
        /// Идентификатор трейдера, от имени которого заключена сделка
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Накопленный купонный доход при выкупе
        /// </summary>
        public double AccuredInt2 { get; set; }

        /// <summary>
        /// Накопленный купонный доход
        /// </summary>
        public double AccuredInt { get; set; }

        /// <summary>
        /// Признак блокировки финансового инструмента на специальном счете на время операции РЕПО
        /// </summary>
        public bool BlockSecurities { get; set; }

        /// <summary>
        /// Величина комиссии  за клиринг по сделке
        /// </summary>
        public double ClearingCenterComission { get; set; }

        /// <summary>
        /// Дата заключения сделки
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// Временные параметры сделки
        /// </summary>
        public int TradeDateTime { get; set; }

        /// <summary>
        /// Величина комиссии за торги по сделке
        /// </summary>
        public double ExchangeComission { get; set; }

        /// <summary>
        /// Дата и время заключения сделки в формате YY.MM.DD HH:MM:SS.MS
        /// </summary>
        public DateTime FileTime { get; set; }

        /// <summary>
        /// Признак маржинальности сделки
        /// </summary>
        public bool IsMarginal { get; set; }

        /// <summary>
        /// Вид сделки
        /// </summary>
        public TradeKind Kind { get; set; }

        /// <summary>
        /// Нижний предел дисконта в процентах
        /// </summary>
        public double LowerDiscount { get; set; }

        /// <summary>
        /// Период, когда была совершена сделка
        /// </summary>
        public TradePeriod Period { get; set; }

        /// <summary>
        /// Цена выкупа
        /// </summary>
        public double Price2 { get; set; }

        /// <summary>
        /// Стоимость выкупа РЕПО
        /// </summary>
        public double Repo2Value { get; set; }

        /// <summary>
        /// Ставка РЕПО в процентах
        /// </summary>
        public double RepoRate { get; set; }

        /// <summary>
        /// Срок РЕПО в календарных днях
        /// </summary>
        public int RepoTerm { get; set; }

        /// <summary>
        /// Сумма РЕПО (сумма привлеченных/предоставленных по сделке РЕПО денежных средств)
        /// </summary>
        public double RepoValue { get; set; }

        /// <summary>
        /// Дата расчетов по сделке
        /// </summary>
        public int SettleDate { get; set; }

        /// <summary>
        /// Начальный дисконт в процентах
        /// </summary>
        public double StartDiscount { get; set; }

        /// <summary>
        /// Время сделки
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Величина комиссии за технический доступ по сделке
        /// </summary>
        public double TradingSystemComission { get; set; }

        /// <summary>
        /// Величина суммарной комиссии по сделке
        /// </summary>
        public double TsComission { get; set; }

        /// <summary>
        /// Верхний предел дисконта в процентах
        /// </summary>
        public double UpperDiscount { get; set; }

        /// <summary>
        /// Доходность сделки
        /// </summary>
        public double Yield { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Account={0} ", this.Account);
            sb.AppendFormat("BrokerRef={0} ", this.BrokerRef);
            sb.AppendFormat("ClientCode={0} ", this.ClientCode);
            sb.AppendFormat("Currency={0} ", this.Currency);
            sb.AppendFormat("ExchangeCode={0} ", this.ExchangeCode);
            sb.AppendFormat("FirmId={0} ", this.FirmId);
            sb.AppendFormat("PartnerFirmId={0} ", this.PartnerFirmId);
            sb.AppendFormat("SettleCode={0} ", this.SettleCode);
            sb.AppendFormat("SettleCurrency={0} ", this.SettleCurrency);
            sb.AppendFormat("StationId={0} ", this.StationId);
            sb.AppendFormat("UserId={0} ", this.UserId);
            sb.AppendFormat("AccuredInt2={0} ", this.AccuredInt2);
            sb.AppendFormat("AccuredInt={0} ", this.AccuredInt);
            sb.AppendFormat("BlockSecurities={0} ", this.BlockSecurities);
            sb.AppendFormat("ClearingCenterComission={0} ", this.ClearingCenterComission);
            sb.AppendFormat("Date={0} ", this.Date);
            sb.AppendFormat("DateTime={0} ", this.TradeDateTime);
            sb.AppendFormat("ExchangeComission={0} ", this.ExchangeComission);
            sb.AppendFormat("FileTime={0} ", this.FileTime);
            sb.AppendFormat("IsMarginal={0} ", this.IsMarginal);
            sb.AppendFormat("Kind={0} ", this.Kind);
            sb.AppendFormat("LowerDiscount={0} ", this.LowerDiscount);
            sb.AppendFormat("Period={0} ", this.Period);
            sb.AppendFormat("Price2={0} ", this.Price2);
            sb.AppendFormat("Repo2Value={0} ", this.Repo2Value);
            sb.AppendFormat("RepoRate={0} ", this.RepoRate);
            sb.AppendFormat("RepoTerm={0} ", this.RepoTerm);
            sb.AppendFormat("RepoValue={0} ", this.RepoValue);
            sb.AppendFormat("SettleDate={0} ", this.SettleDate);
            sb.AppendFormat("StartDiscount={0} ", this.StartDiscount);
            sb.AppendFormat("Time={0} ", this.Time);
            sb.AppendFormat("TradingSystemComission={0} ", this.TradingSystemComission);
            sb.AppendFormat("TsComission={0} ", this.TsComission);
            sb.AppendFormat("UpperDiscount={0} ", this.UpperDiscount);
            sb.AppendFormat("Yield={0} ", this.Yield);

            return sb.ToString().Trim();
        }

        internal static TradeDetails Fetch(Int32 tradeDescriptor, TradeTimeType timeType = TradeTimeType.QuikDate)
        {
            var td = new TradeDetails();

            if (tradeDescriptor <= 0)
            {
                return td;
            }

            ExecHelper.Do(() => { td.Account = TradeEntryPoint.Account(tradeDescriptor); });
            ExecHelper.Do(() => { td.BrokerRef = TradeEntryPoint.BrokerRef(tradeDescriptor); });
            ExecHelper.Do(() => { td.ClientCode = TradeEntryPoint.ClientCode(tradeDescriptor); });
            ExecHelper.Do(() => { td.Currency = TradeEntryPoint.Currency(tradeDescriptor); });
            ExecHelper.Do(() => { td.ExchangeCode = TradeEntryPoint.ExchangeCode(tradeDescriptor); });
            ExecHelper.Do(() => { td.FirmId = TradeEntryPoint.FirmId(tradeDescriptor); });
            ExecHelper.Do(() => { td.PartnerFirmId = TradeEntryPoint.PartnerFirmId(tradeDescriptor); });
            ExecHelper.Do(() => { td.SettleCode = TradeEntryPoint.SettleCode(tradeDescriptor); });
            ExecHelper.Do(() => { td.SettleCurrency = TradeEntryPoint.SettleCurrency(tradeDescriptor); });
            ExecHelper.Do(() => { td.StationId = TradeEntryPoint.StationId(tradeDescriptor); });
            ExecHelper.Do(() => { td.UserId = TradeEntryPoint.UserId(tradeDescriptor); });
            ExecHelper.Do(() => { td.AccuredInt2 = TradeEntryPoint.AccuredInt2(tradeDescriptor); });
            ExecHelper.Do(() => { td.AccuredInt = TradeEntryPoint.AccuredInt(tradeDescriptor); });
            ExecHelper.Do(() => { td.BlockSecurities = TypeConverter.GetBool(TradeEntryPoint.BlockSecurities(tradeDescriptor)); });
            ExecHelper.Do(() => { td.ClearingCenterComission = TradeEntryPoint.ClearingCenterComission(tradeDescriptor); });
            ExecHelper.Do(() => { td.Date = TradeEntryPoint.Date(tradeDescriptor); });
            ExecHelper.Do(() => { td.TradeDateTime = TradeEntryPoint.DateTime(tradeDescriptor, (int)timeType); });
            ExecHelper.Do(() => { td.ExchangeComission = TradeEntryPoint.ExchangeComission(tradeDescriptor); });
            ExecHelper.Do(() => { td.FileTime = TypeConverter.GetDateTime(TradeEntryPoint.FileTime(tradeDescriptor)); });
            ExecHelper.Do(() => { td.IsMarginal = TypeConverter.GetBool(TradeEntryPoint.IsMarginal(tradeDescriptor)); });
            ExecHelper.Do(() => { td.Kind = (TradeKind)TradeEntryPoint.Kind(tradeDescriptor); });
            ExecHelper.Do(() => { td.LowerDiscount = TradeEntryPoint.LowerDiscount(tradeDescriptor); });
            ExecHelper.Do(() => { td.Period = (TradePeriod)TradeEntryPoint.Period(tradeDescriptor); });
            ExecHelper.Do(() => { td.Price2 = TradeEntryPoint.Price2(tradeDescriptor); });
            ExecHelper.Do(() => { td.Repo2Value = TradeEntryPoint.Repo2Value(tradeDescriptor); });
            ExecHelper.Do(() => { td.RepoRate = TradeEntryPoint.RepoRate(tradeDescriptor); });
            ExecHelper.Do(() => { td.RepoTerm = TradeEntryPoint.RepoTerm(tradeDescriptor); });
            ExecHelper.Do(() => { td.RepoValue = TradeEntryPoint.RepoValue(tradeDescriptor); });
            ExecHelper.Do(() => { td.SettleDate = TradeEntryPoint.SettleDate(tradeDescriptor); });
            ExecHelper.Do(() => { td.StartDiscount = TradeEntryPoint.StartDiscount(tradeDescriptor); });
            ExecHelper.Do(() => { td.Time = TradeEntryPoint.Time(tradeDescriptor); });
            ExecHelper.Do(() => { td.TradingSystemComission = TradeEntryPoint.TradingSystemComission(tradeDescriptor); });
            ExecHelper.Do(() => { td.TsComission = TradeEntryPoint.TsComission(tradeDescriptor); });
            ExecHelper.Do(() => { td.UpperDiscount = TradeEntryPoint.UpperDiscount(tradeDescriptor); });
            ExecHelper.Do(() => { td.Yield = TradeEntryPoint.Yield(tradeDescriptor); });

            return td;
        }
    }
}
