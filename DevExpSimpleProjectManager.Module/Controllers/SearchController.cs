using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpSimpleProjectManager.Module.BusinessObjects.Searching;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevExpSimpleProjectManager.Module.Controllers
{
    public class SearchController : ViewController
    {
        public SearchController()
        {
            SimpleAction mySimpleAction = new SimpleAction(this, "MySimpleAction", "MyCategory")
            {
                Caption = "SEARCH"
            };
            mySimpleAction.Execute += MySimpleAction_Execute;
        }

        private async void MySimpleAction_Execute(Object sender, SimpleActionExecuteEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            dynamic nipValueSO = e.SelectedObjects[0];
            var nipValue = nipValueSO.Nip;
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var responseFromWeb = await httpClient.GetAsync($"https://wl-api.mf.gov.pl/api/search/nip/{nipValue}?date={date}");
            var contentString = await responseFromWeb.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDto>(contentString);


            // FOR TESTING PURPOSES
            //await File.WriteAllTextAsync("./contentString.txt", contentString);
            //var responseToFromFile = await File.ReadAllTextAsync("./contentString.txt");
            //var responseDto = JsonConvert.DeserializeObject<ResponseDto>(responseToFromFile);


            var nipCompany = this.ObjectSpace.CreateObject<NipCompany>();
            nipCompany.Nip =  responseDto.Result.subject.nip;
            nipCompany.StatusVat = responseDto.Result.subject.statusVat;
            nipCompany.CompanyName = responseDto.Result.subject.name;
            ObjectSpace.SetModified(nipCompany);
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
    }
}
