using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpSimpleProjectManager.Module.BusinessObjects.Marketing
{
    [NavigationItem("Marketing")]
    public class Customer : BaseObject
    {
        public Customer(Session session) : base(session) { }
        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetPropertyValue(nameof(FirstName), ref firstName, value); }
        }
        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
        }
        string email;
        public string Email
        {
            get { return email; }
            set { SetPropertyValue(nameof(Email), ref email, value); }
        }
        string company;
        public string Company
        {
            get { return company; }
            set { SetPropertyValue(nameof(Company), ref company, value); }
        }
        string occupation;
        public string Occupation
        {
            get { return occupation; }
            set { SetPropertyValue(nameof(Occupation), ref occupation, value); }
        }
        [Association("Customer-Testimonials")]
        public XPCollection<Testimonial> Testimonials
        {
            get { return GetCollection<Testimonial>(nameof(Testimonials)); }
        }
        public string FullName
        {
            get
            {
                string namePart = string.Format("{0} {1}", FirstName, LastName);
                return Company != null ? string.Format("{0} ({1})", namePart, Company) : namePart;
            }
        }
        byte[] photo;
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] Photo
        {
            get { return photo; }
            set { SetPropertyValue(nameof(Photo), ref photo, value); }
        }
    }
    [NavigationItem("Marketing")]
    public class Testimonial : BaseObject
    {
        public Testimonial(Session session) : base(session)
        {
            createdOn = DateTime.Now;
        }
        string quote;
        [Size(SizeAttribute.Unlimited)]
        public string Quote
        {
            get { return quote; }
            set { SetPropertyValue(nameof(Quote), ref quote, value); }
        }
        string highlight;
        [Size(512)]
        public string Highlight
        {
            get { return highlight; }
            set { SetPropertyValue(nameof(Highlight), ref highlight, value); }
        }
        DateTime createdOn;
        [VisibleInListView(false)]
        public DateTime CreatedOn
        {
            get { return createdOn; }
            internal set { SetPropertyValue(nameof(CreatedOn), ref createdOn, value); }
        }
        string tags;
        public string Tags
        {
            get { return tags; }
            set { SetPropertyValue(nameof(Tags), ref tags, value); }
        }
        Customer customer;
        [Association("Customer-Testimonials")]
        public Customer Customer
        {
            get { return customer; }
            set { SetPropertyValue(nameof(Customer), ref customer, value); }
        }
    }
}
