namespace Trans2Quik.Core
{
    using System;
    using System.Text;

    public class StopOrderTransaction : OrderTransaction
    {
        /// <summary>
        /// Стоп-цена за единицу инструмента
        /// </summary>
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// Тип стоп-заявки
        /// </summary>
        public StopOrderKind? OrderKind { get; set; }

        /// <summary>
        /// Класс инструмента условия
        /// </summary>
        public string StopPriceClassCode { get; set; }

        /// <summary>
        /// Код инструмента условия
        /// </summary>
        public string StopPriceSecCode { get; set; }
        
        /// <summary>
        /// Направление предельного изменения стоп-цены
        /// </summary>
        public string StopPriceCondition { get; set; }

        /// <summary>
        /// Цена связанной лимитированной заявки
        /// </summary>
        public decimal? LinkedOrderPrice { get; set; }

        /// <summary>
        /// Цена условия стоп-лимит для заявки типа StopOrderKind.TakeProfitAndStopLimit
        /// </summary>
        public decimal? StopPrice2 { get; set; }

        /// <summary>
        /// Срок действия стоп-заявки
        /// </summary>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Признак исполнения заявки по рыночной цене при наступлении условия "стоп-лимит"
        /// </summary>
        public bool? MarketStopLimit { get; set; }

        /// <summary>
        /// Признак исполнения заявки по рыночной цене при наступлении условаия "тэйк-профит"
        /// </summary>
        public bool? MarketTakeProfit { get; set; }

        /// <summary>
        /// Признак действия заявки типа "Тэйк профит и стоп-лимит" в течение определенного интервала времени
        /// </summary>
        public bool? IsActiveInTime { get; set; }

        /// <summary>
        /// Время начала действия заявки типа "Тэйк профит и стоп-лимит"
        /// </summary>
        public DateTime? ActiveFromTime { get; set; }

        /// <summary>
        /// Время окончания действия заявки типа "Тэйк профит и стоп-лимит"
        /// </summary>
        public DateTime? ActiveToTime { get; set; }

        /// <summary>
        /// Номер стоп-заявки, снимаемой с торговой системы
        /// </summary>
        public int? StopOrderKey { get; set; }

        /// <summary>
        /// Величина отступа от максимума (минимума) цены последней сделки.
        /// </summary>
        public decimal? Offset { get; set; }

        /// <summary>
        /// Единицы измерения отступа
        /// </summary>
        public Units? OffsetUnits { get; set; }

        /// <summary>
        /// Величина защитного спрэда
        /// </summary>
        public decimal? Spread { get; set; }

        /// <summary>
        /// Единицы измерения защитного спрэда
        /// </summary>
        public Units? SpreadUnits { get; set; }

        /// <summary>
        /// Регистрационный номер заявки-условия
        /// </summary>
        public int? BaseOrderKey { get; set; }

        /// <summary>
        /// Признак использования в качестве объема заявки "по исполнению" исполненного количества бумаг заявки-условия.
        /// </summary>
        public bool? UseBaseOrderBalance { get; set; }
        
        /// <summary>
        /// Признак активации заявки "по исполнению" при частичном исполнении заявки-условия.
        /// </summary>
        public bool? ActivateIfBaseOrderPartlyFilled { get; set; }

        
        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            return sb.ToString().Trim();
        }
    }

}
