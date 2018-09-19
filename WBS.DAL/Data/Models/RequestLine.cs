using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class RequestLine : IBaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int Quantity { get; set; }
        public int OldQuantity { get; set; }
        public int Amortization { get; set; }

        //relationships
        public int RequestId { get; set; }
        public DAIRequest Request { get; set; }

        public int BudgetLineId { get; set; }
        public BudgetLine BudgetLine { get; set; }

        //ссылка подстроки на родительскую строку
        public int ParentRequestLineId { get; set; }
        public RequestLine ParentRequestLine { get; set; }

        public int ByWhoRequestLineId { get; set; }
        public RequestLine ByWhoRequestLine { get; set; }

        public int CategoryOfEquipmentId { get; set; }
        public CategoryOfEquipment CategoryOfEquipment { get; set; }

        public int? ResultCenterId { get; set; }
        public ResultCenter ResultCenter { get; set; }

        public int SiteId { get; set; }
        public Site Site { get; set; }

        public int TypeOfInvestmentId { get; set; }
        public TypeOfInvestment TypeOfInvestment { get; set; }

        //подстроки
        public List<RequestLine> RequestSubLines { get; set; }
        //линии, за счет которых создается линия в пакете
        public List<RequestLine> OnAccountOfRequestLines { get; set; }

        [NotMapped]
        public bool IsRealBudgetLine
        {
            get
            {
                return BudgetLine != null && ParentRequestLine == null;
            }
        }

        public RequestLineType RequestLineType
        {
            get
            {
                if(ParentRequestLine != null)
                {
                    return RequestLineType.BudgetSubLine;
                }
                else if(ByWhoRequestLine != null)
                {
                    return RequestLineType.InPacketOnAccountOf;
                }
                else if (BudgetLine != null)
                {
                    return RequestLineType.BudgetLine;
                }
                else if (OnAccountOfRequestLines.Any())
                {
                    return RequestLineType.InPacket;
                }
                else
                {
                    return RequestLineType.OutOfBudget;
                }
            }
        }
    }

    public enum RequestLineType
    {
        BudgetLine,
        BudgetSubLine,
        OutOfBudget,
        InPacket,
        InPacketOnAccountOf
    }
}
