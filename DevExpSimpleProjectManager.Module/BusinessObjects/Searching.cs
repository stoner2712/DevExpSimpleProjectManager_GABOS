using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpSimpleProjectManager.Module.BusinessObjects.Searching
{
    public class ResponseDto
    {
        public ResultDto Result { get; set;}
    }

    public class ResultDto
    {
        public SubjectDto subject { get; set; }
        public string requestId { get; set; }
        public string requestDateTime { get; set; }
    }

    public class SubjectDto
    {
        public string nip { get; set; }
        public string name { get; set; }
        public string statusVat { get; set; }
    }

    [NavigationItem("Searching")]
    public class NipCompany : BaseObject 
    {
        public NipCompany(Session session) : base(session) { }

        string nip;
        public string Nip
        {
            get { return nip; }
            set { SetPropertyValue(nameof(Nip), ref nip, value); }
        }
        string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { SetPropertyValue(nameof(CompanyName), ref companyName, value); }
        }
        string statusVat;
        public string StatusVat
        {
            get { return statusVat; }
            set { SetPropertyValue(nameof(StatusVat), ref statusVat, value); }
        }
    }
}
